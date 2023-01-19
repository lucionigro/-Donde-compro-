using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Donde_Compro.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(50)]
        public string Correo { get; set; }
        [StringLength(25)]
        public string Clave { get; set; }
        [StringLength(70)]
        public string Direccion { get; set; }
        public DateTime Nacimiento { get; set; }

        public Rol Rol { get; set; }
        public int Roltype { get; set; }

        [DisplayName("Tipo de pago")]
        public UsuarioPago UsuarioPago { get; set; }
        public int? UsuarioPagoId { get; set; }

        public Orden Orden { get; set; }
    }
}
