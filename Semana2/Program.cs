

using Clase1;
using Encapsulamiento;
using Herencia;
using Polimorfismo;
using Abastraccion;


// Clases
Clase clase = new Clase();
// clase.MostrarDatos();
Clase clase1 = new Clase("Ana", 30);
// clase1.MostrarDatos();

// Encapsulamiento
Persona persona = new Persona("Luis", 25, "Calle Falsa 123");
// persona.MostrarDatos();
persona.Edad = 28; // Usando el set
// persona.MostrarDatos();
// persona.Edad = -5; 
// Intento de asignar edad no válida


// Herencia
Moto moto = new Moto("Yamaha", true);
// moto.MostrarInfo();
// moto.Arrancar();

// Polimorfismo
// Gato gato = new Gato();
// gato.HacerSonido();
// Perro perro = new Perro();
// perro.HacerSonido();

// Abstracción
Cuadrado cuadrado = new Cuadrado(5);
// Console.WriteLine("Cuadrado:", cuadrado.CalcularArea()); 
Circulo circulo = new Circulo(3);
// Console.WriteLine("Círculo:", circulo.CalcularArea());


