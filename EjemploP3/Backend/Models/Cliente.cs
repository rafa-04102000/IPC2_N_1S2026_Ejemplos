namespace Backend.Models
{
    public class Cliente
    {
        public string NIT { get; set; } = string.Empty; // Usado en config.xml y transac.xml
        public string Nombre { get; set; } = string.Empty;
        public decimal SaldoAFavor { get; set; } = 0; // Para el manejo de pagos excedentes
    }
}
