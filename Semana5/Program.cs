using EjListaCircular;
using EjListaDoblementeCircular;

// Lista Circular
ListaCircular lista = new ListaCircular();
lista.append(new EjListaCircular.Nodo(new EjListaCircular.Libro("Cien Años de Soledad", "Gabriel García Márquez", 1967)));
lista.append(new EjListaCircular.Nodo(new EjListaCircular.Libro("Don Quijote de la Mancha", "Miguel de Cervantes", 1605))); 
lista.append(new EjListaCircular.Nodo(new EjListaCircular.Libro("La Sombra del Viento", "Carlos Ruiz Zafón", 2001)));
lista.print();


// Lista Doblemente Circular
ListaDoblementeCircular listaDoble = new ListaDoblementeCircular();
listaDoble.append(new EjListaDoblementeCircular.Nodo(new EjListaDoblementeCircular.Libro("Cien Años de Soledad", "Gabriel García Márquez", 1967)));
listaDoble.append(new EjListaDoblementeCircular.Nodo(new EjListaDoblementeCircular.Libro("Don Quijote de la Mancha", "Miguel de Cervantes", 1605)));
listaDoble.append(new EjListaDoblementeCircular.Nodo(new EjListaDoblementeCircular.Libro("La Sombra del Viento", "Carlos Ruiz Zafón", 2001)));
listaDoble.print();