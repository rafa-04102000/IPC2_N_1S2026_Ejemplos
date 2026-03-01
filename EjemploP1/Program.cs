using System.Xml.Linq;
using EjemploP1;


int opcion = 0;

Tableros tableros = new Tableros();

while (opcion != 6)
{
    Console.WriteLine("--------------Menú--------------");
    Console.WriteLine("1. Cargar datos de Tableros");
    Console.WriteLine("2. Lista de Tableros");
    Console.WriteLine("3. Mostrar Patron Inicial de un Tablero");
    Console.WriteLine("4. Mostrar Grafica de un Tablero");
    Console.WriteLine("5. Realizar periodos del tablero para mostrar su evolución");
    Console.WriteLine("6. Salir");
    Console.WriteLine("--------------------------------");
    Console.WriteLine("Seleccione una opción: ");
    Console.WriteLine("--------------------------------");

    opcion = int.TryParse(Console.ReadLine(), out int parsedOption) ? parsedOption : 0;

    Console.WriteLine("--------------------------------");


    switch (opcion)
    {
        case 1:
            Console.WriteLine("Ingrese el nombre de su archivo, sin la extension, ya que se asume que es .xml");
            Console.WriteLine("--------------------------------");

            string? nombreArchivo = Console.ReadLine();
            Console.WriteLine("--------------------------------");

            if (string.IsNullOrEmpty(nombreArchivo))
            {
                Console.WriteLine("Nombre de archivo no válido. Por favor, intente nuevamente.");
                break;
            }
            CargarDatosTableros(nombreArchivo);
            break;
        case 2:
            tableros.print();
            break;
        case 3:
            Console.WriteLine("Ingreese el nombre del tablero del cual desea mostrar su patrón inicial");
            Console.WriteLine("--------------------------------");

            string? nombreTablero = Console.ReadLine();
            Console.WriteLine("--------------------------------");
            Tablero? tablero = tableros.buscarTablero(nombreTablero);
            if (tablero != null)
            {
                tablero.PatronInicial.printRejilla();
            }
            else
            {
                Console.WriteLine("Tablero no encontrado.");
            }
            break;
        case 4:
            Console.WriteLine("Ingreese el nombre del tablero del cual desea mostrar su grafica");
            Console.WriteLine("--------------------------------");

            string? tableroAGraficar = Console.ReadLine();
            Console.WriteLine("--------------------------------");
            Tablero? tableroE = tableros.buscarTablero(tableroAGraficar);
            if (tableroE != null)
            {
                tableroE.PatronInicial.graficarRejillaV1(tableroE.Nombre);
            }
            else
            {
                Console.WriteLine("Tablero no encontrado.");
            }
            break;
        case 5:
            Console.WriteLine("Ingresar el nombre del tablero del cual desea realizar los periodos");
            Console.WriteLine("--------------------------------");

            string? tableroPeriodos = Console.ReadLine();
            Console.WriteLine("--------------------------------");
            Tablero? tableroP = tableros.buscarTablero(tableroPeriodos);
            if (tableroP != null)
            {
                tableroP.ListaPeriodos.realizarPeriodos(tableroP.Nombre, tableroP.NumeroPeriodos);
            }
            else
            {
                Console.WriteLine("Tablero no encontrado.");
            }
            break;
        case 6:
            Console.WriteLine("Saliendo del programa.");
            break;
        default:
            Console.WriteLine("Opción no válida.");
            break;
    }
}

void CargarDatosTableros(string nombreArchivo)
{
    string rutaCarptea = "ArchivosEntrada/";

    // Valido si existe el archivo, si no existe, se muestra un mensaje de error y se retorna para que el programa siga funcionando
    if (!File.Exists($"{rutaCarptea}{nombreArchivo}.xml"))
    {
        Console.WriteLine("Archivo no encontrado. Por favor, verifique el nombre del archivo y su ubicación.");
        return;
    }


    XDocument doc = XDocument.Load($"{rutaCarptea}{nombreArchivo}.xml");

    var listaTableros = from tablero in doc.Descendants("tablero")
                        // el select new es una forma de proyectar los datos que queremos obtener del XML, en este caso, estamos creando un objeto anónimo con las propiedades Nombre, NumeroPeriodos, TamanoRejilla y Rejilla, que se corresponden con los elementos del XML. Esto nos permite trabajar con los datos de una manera más estructurada y fácil de manejar en nuestro programa.
                        select new
                        {
                            // aca solo puedo poner declaraciones de variables
                            Nombre = tablero.Element("nombre")?.Value,
                            NumeroPeriodos = int.Parse(tablero.Element("periodos")?.Value ?? "0"),
                            TamanoRejilla = int.Parse(tablero.Element("m")?.Value ?? "0"),
                            // en el xml esta rejilla, tiene elementos celda y la celda tiene atrubuto f y c, es f de fila y c de columna
                            // hago una lista de nombre rejilla y elementos columna
                            Rejilla = from celda in tablero.Descendants("celda")
                                      let fila = celda.Attribute("f")?.Value
                                      let columna = celda.Attribute("c")?.Value
                                      // si no ponemos la palabra select new, si no solo select, lo que obtenemos es una lista de strings con el formato "Fila: {fila}, Columna: {columna}", pero si queremos obtener un objeto con las propiedades Fila y Columna, tenemos que usar select new, para proyectar los datos en un objeto anónimo con esas propiedades, de esta forma podemos acceder a ellas de manera más fácil en nuestro programa, por ejemplo, podríamos hacer algo como rejilla.Fila para obtener el valor de la fila de esa celda.
                                      //  select $"Fila: {fila}, Columna: {columna}"
                                      select new
                                      {
                                          Fila = int.Parse(fila ?? "0"),
                                          Columna = int.Parse(columna ?? "0")
                                      },
                        };

    foreach (var tablero in listaTableros)
    {
        Tablero nuevoTablero = new Tablero(tablero.Nombre, tablero.NumeroPeriodos, tablero.TamanoRejilla);

        Console.WriteLine($"Tablero: {tablero.Nombre} con {tablero.NumeroPeriodos} periodos y tamaño {tablero.TamanoRejilla}x{tablero.TamanoRejilla}");
        Console.WriteLine("Rejilla:");

        // Patron inicial
        Rejilla rejilla = new Rejilla(0, nuevoTablero.TamanoRejilla);

        // creo el for donde creo la Rejilla, adentro coloco el foreach para ver si en la fila y columna donde voy
        // tengo valores del XML, esos significa que ahi debo poner un 1, para todo lo demas lo rellno con 0

        for (int fila = 1; fila <= tablero.TamanoRejilla; fila++)
        {
            for (int columna = 1; columna <= tablero.TamanoRejilla; columna++)
            {
                bool celdaExiste = tablero.Rejilla.Any(c => c.Fila == fila && c.Columna == columna);
                Casilla nuevaCasilla = new Casilla(fila, columna, celdaExiste ? 1 : 0);
                rejilla.append(nuevaCasilla);
            }
        }

        nuevoTablero.PatronInicial = rejilla;

        // este es solo para mostrar
        // foreach (var celda in tablero.Rejilla)
        // {
        //     Console.WriteLine($"Fila: {celda.Fila}, Columna: {celda.Columna}");
        // }

        // creo la lista de periodos, y le paso como parametro la rejilla inicial
        nuevoTablero.ListaPeriodos = new ListaPeriodos(rejilla);

        // agrego el tablero a la lista de tableros
        tableros.append(nuevoTablero);

        Console.WriteLine("--------------------------------");
    }

}