using Microsoft.EntityFrameworkCore;
using TechChallengeWeb.Models;

public class ApplicationContext : DbContext
{     
        public ApplicationContext(DbContextOptions<ApplicationContext> opts) : base(opts) { }
        public DbSet<Foto> Fotos { get; set; }
        public DbSet<Publicacao> Publicacoes { get; set;  }
        public DbSet<Usuario> Usuarios { get; set; }
}
