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
        [DisplayName("Contraseña")]
        public string Clave { get; set; }
        [StringLength(70)]
        public string Direccion { get; set; }
        public DateTime Nacimiento { get; set; }

        public Rol Rol { get; set; }
        [DisplayName("Rol")]
        public int Roltype { get; set; }

        
        public UsuarioPago UsuarioPago { get; set; }
        [DisplayName("Tipo de pago")]
        public int TipoDePago { get; set; }

        public Orden Orden { get; set; }
    }
}
