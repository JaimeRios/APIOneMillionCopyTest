using APIOneMillionCopyTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIOneMillionCopyTest.Infrastructure.Persistence
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        public DbSet<Lead> Leads => Set<Lead>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lead>(entity =>
            {
                entity.ToTable("leads");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
                entity.HasIndex(e => e.Email).IsUnique();

                entity.Property(e => e.Fuente)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Presupuesto)
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Nombre).HasColumnName("nombre");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.Telefono).HasColumnName("telefono");
                entity.Property(e => e.Fuente).HasColumnName("fuente");
                entity.Property(e => e.ProductoInteres).HasColumnName("producto_interes");
                entity.Property(e => e.Presupuesto).HasColumnName("presupuesto");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });
        }
    }
}
