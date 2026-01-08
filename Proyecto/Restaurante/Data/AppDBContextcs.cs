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

        public DbSet<Roles> Roles { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Restaurantes> Restaurantes { get; set; }
        public DbSet<Mesas> Mesas { get; set; }
        public DbSet<HorariosTrabajador> Horarios { get; set; }
        public DbSet<EstadoPedido> EstadosPedidos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallesPedidos> DetallesPedidos { get; set; }
        public DbSet<CategoriasProcuctos> CategoriasProcuctos { get; set; }
        public DbSet<EstadosReservas> EstadosReservas { get; set; }
        public DbSet<Reservas> Reservas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuarios>()
                .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<DetallesPedidos>()
         .HasKey(dp => new { dp.IdProducto, dp.IdPedido });
        }
    }
}
