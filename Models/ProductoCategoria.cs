using System.ComponentModel.DataAnnotations;

namespace Donde_Compro.Models
{
    public class ProductoCategoria
    {
        public int CategoriaId { get; set; }
        [StringLength(100)]
        public string NombreCategoria { get; set; }
        public List<Producto> Producto { get; set; }
    }
}
