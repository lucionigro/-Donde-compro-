using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Donde_Compro.Models
{
    public class Orden
    {
        public int OrdenId { get; set; }
        public int Cantidad { get; set; }
        [DisplayName("Fecha de compra")]
        public DateTime DiaDeCompra { get; set; }

        public Usuario Usuario { get; set; }
        [DisplayName("Usuario ID")]
        public int? UsuarioId { get; set; }

        [DisplayName("Producto ID")]
        public int? ProductoId { get; set; }
        public Producto Producto { get; set; }
    }
}
