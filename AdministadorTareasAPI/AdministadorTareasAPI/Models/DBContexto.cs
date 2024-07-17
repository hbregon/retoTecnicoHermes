using Microsoft.EntityFrameworkCore;
namespace AdministadorTareasAPI.Models
{
    public class DBContexto : DbContext
    {
        public DBContexto() { }

        public DBContexto(DbContextOptions<DBContexto> opciones) : base(opciones) { }

        public DbSet<Tarea> Tareas { get; set; } = null!;
        public DbSet<Colaborador> Colaboradores { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.HasKey(e => e.IdTarea)
                    .HasName("PK_Tarea");

                entity.ToTable("Tarea");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Prioridad)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .IsUnicode(false);

                entity.Property(e => e.FechaFin)
                    .HasColumnType("datetime")
                    .IsUnicode(false);

                entity.Property(e => e.Nota)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ObjetoColaborador)
                   .WithMany(p => p.Tareas)
                   .HasForeignKey(d => d.IdColaborador)
                   .HasConstraintName("FK_Tarea_Colaborador");
            });

            modelBuilder.Entity<Colaborador>(entity =>
            {
                entity.HasKey(e => e.IdColaborador)
                    .HasName("PK_Colaborador");

                entity.ToTable("Colaborador");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

        }
    }
}

