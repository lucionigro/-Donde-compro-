using System.ComponentModel.DataAnnotations;

namespace Donde_Compro.Models
{
    public class Rol
    {
        public int RolId { get; set; }
        [Range(1, 3)]
        public int RolType { get; set; }
        public List<Usuario> Usuario { get; set; }
    }
}
