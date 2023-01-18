namespace Donde_Compro.Models
{
    public class Orden
    {
        public int OrdenId { get; set; }
        public int Cantidad { get; set; }
        public DateTime DiaDeCompra { get; set; }


        public int? UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public List<Producto> Producto { get; set; }
    }
}
