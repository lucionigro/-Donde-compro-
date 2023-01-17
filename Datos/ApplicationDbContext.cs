using Microsoft.EntityFrameworkCore;
using Donde_Compro.Models;

namespace Donde_Compro.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opciones) : base(opciones)
        {

        }

        //Agregar modelos abajo:
    }
}
