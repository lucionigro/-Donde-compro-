using System.ComponentModel.DataAnnotations;

namespace Donde_Compro.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(350)]
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public DateTime Publicado { get; set; }

        public ProductoCategoria ProductoCategoria { get; set; }
        public int CategoriaId { get; set; }

        public int OrdenId { get; set; }
        public Orden Orden { get; set; }
    }
}
