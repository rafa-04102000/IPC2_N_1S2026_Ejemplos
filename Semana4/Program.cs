
using EjListaEnalazadaSimple;
using EjListaDoblementeEnlazada;


// ListaEnalazadaSimple lista = new ListaEnalazadaSimple();
// lista.append(new Nodo(new Pelicula("El Padrino", "Francis Ford Coppola", 1972)));
// lista.append(new Nodo(new Pelicula("El Padrino II", "Francis Ford Coppola", 1974)));
// lista.append(new Nodo(new Pelicula("El Padrino III", "Francis Ford Coppola", 1990)));
// lista.append(new Nodo(new Pelicula("El Padrino IV", "Francis Ford Coppola", 2024)));
// lista.print();
// lista.pop();
// Console.WriteLine("Después de eliminar el último nodo:");
// lista.print();

ListaDoblementeEnlazada lista2 = new ListaDoblementeEnlazada();
lista2.append(new Nodo2(new Libro("Cien Años de Soledad", "Gabriel García Márquez", 1967)));
lista2.append(new Nodo2(new Libro("Don Quijote de la Mancha", "Miguel de Cervantes", 1605)));
lista2.append(new Nodo2(new Libro("La Sombra del Viento", "Carlos Ruiz Zafón", 2001)));
Console.WriteLine("Impresión hacia adelante:");
lista2.printAdelante();
Console.WriteLine("Impresión hacia atrás:");  
lista2.printAtras();
lista2.pop();
Console.WriteLine("Después de eliminar el último nodo:");
Console.WriteLine("Impresión hacia adelante:");
lista2.printAdelante();
Console.WriteLine("Impresión hacia atrás:");
lista2.printAtras();