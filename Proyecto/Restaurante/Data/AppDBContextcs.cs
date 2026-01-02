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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuarios>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
