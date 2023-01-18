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
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<UsuarioPago> UsuarioPago { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<ProductoCategoria> ProductoCategoria { get; set; }
        public DbSet<Orden> Orden { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasKey(c => c.UsuarioId);
            modelBuilder.Entity<Usuario>().Property(c => c.Nombre).IsRequired();
            modelBuilder.Entity<Usuario>().Property(c => c.Correo).IsRequired();
            modelBuilder.Entity<Usuario>().Property(c => c.Clave).IsRequired();
            modelBuilder.Entity<Usuario>().Property(c => c.Direccion).IsRequired();
            modelBuilder.Entity<Usuario>().Property(c => c.Nacimiento).HasColumnType("date").IsRequired();

            modelBuilder.Entity<UsuarioPago>().HasKey(c => c.UsuarioPagoId);
            modelBuilder.Entity<UsuarioPago>().Property(c => c.TipoDePago).IsRequired();

            modelBuilder.Entity<Rol>().HasKey(c => c.RolId);
            modelBuilder.Entity<Rol>().Property(c => c.RolType).IsRequired();

            modelBuilder.Entity<Producto>().HasKey(c => c.ProductoId);
            modelBuilder.Entity<Producto>().Property(c => c.Nombre).IsRequired();
            modelBuilder.Entity<Producto>().Property(c => c.Descripcion).IsRequired();
            modelBuilder.Entity<Producto>().Property(c => c.Precio).IsRequired();
            modelBuilder.Entity<Producto>().Property(c => c.Publicado).HasColumnType("date");

            modelBuilder.Entity<ProductoCategoria>().HasKey(c => c.CategoriaId);
            modelBuilder.Entity<ProductoCategoria>().Property(c => c.NombreCategoria).IsRequired();

            modelBuilder.Entity<Orden>().HasKey(c => c.OrdenId);
            modelBuilder.Entity<Orden>().Property(c => c.Cantidad).IsRequired();
            modelBuilder.Entity<Orden>().Property(c => c.DiaDeCompra).HasColumnType("date").IsRequired();

            //Relacion uno a muchos (Rol y Usuario)
            modelBuilder.Entity<Usuario>()
                .HasOne(c => c.Rol)
                .WithMany(c => c.Usuario).HasForeignKey(c => c.Roltype);

            //Relacion uno a uno (Usuario y UsuarioPago)
            modelBuilder.Entity<Usuario>()
                .HasOne(c => c.UsuarioPago)
                .WithOne(c => c.Usuario).HasForeignKey<Usuario>("UsuarioPagoId");

            //Relacion uno a muchos (Categoria y Producto)
            modelBuilder.Entity<Producto>()
                .HasOne(c => c.ProductoCategoria)
                .WithMany(c => c.Producto).HasForeignKey(c => c.CategoriaId);

            //Relacion uno a muchos (Orden y Producto)
            modelBuilder.Entity<Orden>()
                .HasOne(c => c.Producto)
                .WithMany(c => c.Orden).HasForeignKey(c => c.ProductoId);

            //Relacion uno a uno (Orden y Usuario)
            modelBuilder.Entity<Orden>()
                .HasOne(c => c.Usuario)
                .WithOne(c => c.Orden).HasForeignKey<Orden>("UsuarioId");

            base.OnModelCreating(modelBuilder);
        }
    }
}
