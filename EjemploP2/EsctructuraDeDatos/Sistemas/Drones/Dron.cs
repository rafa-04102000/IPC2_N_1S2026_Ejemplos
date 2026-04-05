namespace EjemploP2.EsctructuraDeDatos.Sistemas.Drones
{
    public class Dron
    {
        public string Nombre;
        public Dron? Siguiente;

        public Dron(string nombre)
        {
            Nombre = nombre;
            Siguiente = null;
        }
    }
}
