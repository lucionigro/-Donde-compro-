using System.ComponentModel;
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
        [DisplayName("Fecha de Publicacion")]
        public DateTime Publicado { get; set; }

        
        public ProductoCategoria ProductoCategoria { get; set; }
        [DisplayName("Categoria del Producto")]
        public int CategoriaId { get; set; }

        public List<Orden> Orden { get; set; }
    }
}
