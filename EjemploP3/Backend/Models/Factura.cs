namespace Backend.Models
{
    public class Factura
    {
        public string NumeroFactura { get; set; } = string.Empty; // Ej: "FAC001"
        public string NITCliente { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public decimal SaldoPendiente { get; set; }
        public bool Pagada { get; set; } = false;
    }
}
