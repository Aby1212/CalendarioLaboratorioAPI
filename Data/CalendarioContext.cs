using Demo.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data
{
    public class CalendarioContext : DbContext
    {
        public CalendarioContext(DbContextOptions<CalendarioContext> options) : base(options) { }

        public DbSet<Pais> Pais { get; set; } = null!;
        public DbSet<TipoFestivo> TipoFestivos { get; set; } = null!;
        public DbSet<Festivo> Festivos { get; set; } = null!;
        public DbSet<Tipo> Tipos { get; set; } = null!;
        public DbSet<Calendario> Calendarios { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
      
            modelBuilder.Entity<Pais>(entity =>
            {
                entity.ToTable("pais");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Nombre).HasColumnName("nombre").HasMaxLength(100);
            });

          
            modelBuilder.Entity<TipoFestivo>(entity =>
            {
                entity.ToTable("tipofestivo");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Tipo).HasColumnName("tipo").HasMaxLength(50);
            });

         
            modelBuilder.Entity<Festivo>(entity =>
            {
                entity.ToTable("festivo");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.IdPais).HasColumnName("idpais");
                entity.Property(e => e.Nombre).HasColumnName("nombre").HasMaxLength(100);
                entity.Property(e => e.Dia).HasColumnName("dia");
                entity.Property(e => e.Mes).HasColumnName("mes");
                entity.Property(e => e.DiasPascua).HasColumnName("diaspascua");
                entity.Property(e => e.IdTipo).HasColumnName("idtipo");

                entity.HasOne(d => d.Pais)
                    .WithMany(p => p.Festivos)
                    .HasForeignKey(d => d.IdPais);

                entity.HasOne(d => d.TipoFestivo)
                    .WithMany(p => p.Festivos)
                    .HasForeignKey(d => d.IdTipo);
            });

          
            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.ToTable("tipo");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Tipo1).HasColumnName("tipo").HasMaxLength(50);
            });

         
            modelBuilder.Entity<Calendario>(entity =>
            {
                entity.ToTable("calendario");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Fecha).HasColumnName("fecha");
                entity.Property(e => e.IdTipo).HasColumnName("idtipo");
                entity.Property(e => e.Descripcion).HasColumnName("descripcion").HasMaxLength(200);
                entity.Property(e => e.IdPais).HasColumnName("idpais");

                entity.HasOne(d => d.Tipo)
                    .WithMany(p => p.Calendarios)
                    .HasForeignKey(d => d.IdTipo);

                entity.HasOne(d => d.Pais)
                    .WithMany(p => p.Calendarios)
                    .HasForeignKey(d => d.IdPais);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}