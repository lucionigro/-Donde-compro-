namespace Donde_Compro.Models
{
    public class UsuarioPago
    {
        public int UsuarioPagoId { get; set; }
        public string TipoDePago { get; set; }
        public Usuario Usuario { get; set; }
    }
}
