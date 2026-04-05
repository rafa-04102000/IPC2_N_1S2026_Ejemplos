namespace EjemploP2.EsctructuraDeDatos.Sistemas.Drones
{
    public class ListaDrones
    {
        public Dron? Raiz;

        public void Append(Dron nuevoDron)
        {
            if (Raiz == null)
            {
                Raiz = nuevoDron;
            }
            else
            {
                Dron? dronActual = Raiz;
                while (dronActual.Siguiente != null)
                {
                    dronActual = dronActual.Siguiente;
                }
                dronActual.Siguiente = nuevoDron;
            }
        }


        // Buscar Dron por nombre, devuelve el Dron si lo encuentra, sino devuelve null
        public Dron? Search(string nombre)
        {
            Dron? dronActual = Raiz;
            while (dronActual != null)
            {
                if (dronActual.Nombre == nombre)
                {
                    return dronActual;
                }
                dronActual = dronActual.Siguiente;
            }

            return null;
        }


        // Agregar un Dron manualmente
        public void AgregarDron(string nombreDron)
        {
            // Busco si el dron ya existe
            Dron? dronBuscado = Search(nombreDron);
            if (dronBuscado == null)
            {
                Dron nuevoDron = new Dron(nombreDron);
                this.Append(nuevoDron);
            }
            else
            {
                throw new Exception("Ya existe un dron con ese nombre");
            }
        }

        // Metodos Especiales para devovler arreglos, o DTOs, o lo que necesite para mostrar en la vista, o para usar en el controlador, etc
        // DTO es como un JSON

        public string[] ArrayDrones()
        {
            List<string> nombresDrones = new List<string>();
            Dron? dronActual = Raiz;
            while (dronActual != null)
            {
                nombresDrones.Add(dronActual.Nombre);
                dronActual = dronActual.Siguiente;
            }
            return nombresDrones.ToArray();
        }

    }
}
