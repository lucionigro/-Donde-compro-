using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Donde_Compro.Models
{
    public class UsuarioPago
    {
        public int UsuarioPagoId { get; set; }
        [DisplayName("Tipo de pago")]
        [Range(1,2)]
        public int TipoDePago { get; set; }
        public Usuario Usuario { get; set; }
    }
}
