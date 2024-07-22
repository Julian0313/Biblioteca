using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Dominio.Modelo
{
    public class LibreriaContext : DbContext
    {
        public LibreriaContext(DbContextOptions<LibreriaContext> options) : base(options)
        {
        }

        public DbSet<AuditoriaAutor> AuditoriaAutores { get; set; }

        public DbSet<AuditoriaLibro> AuditoriaLibros { get; set; }

        public DbSet<Autor> Autores { get; set; }

        public DbSet<Estado> Estados { get; set; }

        public DbSet<Libro> Libros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditoriaAutor>()
               .HasKey(aa => aa.IdAuditoriaAutor);

            modelBuilder.Entity<AuditoriaLibro>()
              .HasKey(al => al.IdAuditoriaLibro);

            modelBuilder.Entity<Autor>()
              .HasKey(a => a.IdAutor);

            modelBuilder.Entity<Estado>()
             .HasKey(e => e.IdEstado);

            modelBuilder.Entity<Libro>()
             .HasKey(l => l.IdLibro);

            //Llaves foraneas 

            modelBuilder.Entity<Libro>()
                 .HasOne(e => e.Estado)
                 .WithMany()
                 .HasForeignKey(p => p.FkIdEstado);

            modelBuilder.Entity<Libro>()
                  .HasOne(a => a.Autor)
                  .WithMany()
                  .HasForeignKey(p => p.FkIdAutor);           

            base.OnModelCreating(modelBuilder);

        }
        public class LibreriaContextFactory : IDesignTimeDbContextFactory<LibreriaContext>
        {
            public LibreriaContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<LibreriaContext>();
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=Biblioteca;User Id=postgres;Pwd=Julian_256245;TrustServerCertificate=true;");

                return new LibreriaContext(optionsBuilder.Options);
            }
        }
    }
}
