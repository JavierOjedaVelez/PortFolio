using Restaurante.Models;
using Microsoft.EntityFrameworkCore;

namespace Restaurante.Data
{
    public class AppDBContextcs : DbContext
    {
        public AppDBContextcs(DbContextOptions<AppDBContextcs> options)
            : base(options)
        {

        }

        public DbSet<Roles> Roles { get; set; } //esta
        public DbSet<Usuarios> Usuarios { get; set; } //esta
        public DbSet<Restaurantes> Restaurantes { get; set; } //esta
        public DbSet<Mesas> Mesas { get; set; } //está
        public DbSet<HorariosTrabajador> Horarios { get; set; } //está
        public DbSet<EstadoPedido> EstadosPedidos { get; set; } //está
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallesPedidos> DetallesPedidos { get; set; }
        public DbSet<CategoriasProcuctos> CategoriasProcuctos { get; set; }
        public DbSet<EstadosReservas> EstadosReservas { get; set; }
        public DbSet<Reservas> Reservas { get; set; }
        public DbSet<Ingredientes> Ingredientes { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<ProductosIngredientes> ProductosIngredientes { get; set; }
        public DbSet<TiposPromocion> TiposPromocion { get; set; }
        public DbSet<Promociones> Promociones { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuarios>()
                .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<DetallesPedidos>()
         .HasKey(dp => new { dp.IdProducto, dp.IdPedido });
            modelBuilder.Entity<ProductosIngredientes>()
    .HasKey(pi => new { pi.IdProducto, pi.IdIngrediente });

        }
    }
}
