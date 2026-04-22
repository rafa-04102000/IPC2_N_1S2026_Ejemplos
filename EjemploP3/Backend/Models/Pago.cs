namespace Backend.Models
{
    public class Pago
    {
        public string CodigoBanco { get; set; } = string.Empty;
        public string NITCliente { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
    }
}
