using Microsoft.EntityFrameworkCore;
using HelpDesk.Models;

namespace HelpDesk.Infraestrutura
{
    public class ConnectionContext : DbContext
    {
        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options) { }

        public DbSet<Usuarios> Usuarios {get; set;}
        public DbSet<Chamados> Chamados {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração para garantir que o e-mail seja único
            modelBuilder.Entity<Usuarios>()
                .HasIndex(u => u.Email)
                .IsUnique(); 

            // Define "Usuario" como padrão para TipoUsuario
            modelBuilder.Entity<Usuarios>()
                .Property(u => u.TipoUsuario)
                .HasDefaultValue("Usuario"); 

            // Configuração do campo DataCriacao para usar o valor padrão do SQL Server
            modelBuilder.Entity<Chamados>()
                .Property(c => c.DataCriacao)
                .HasDefaultValueSql("GETDATE()");

            // Definindo o relacionamento explícito entre Chamados e Usuarios
            modelBuilder.Entity<Chamados>()
                .HasOne(c => c.Usuario) // Um Chamado tem um Usuario
                .WithMany(u => u.Chamados) // Um Usuario pode ter muitos Chamados
                .HasForeignKey(c => c.UsuarioId) // Define a chave estrangeira em Chamados
                .OnDelete(DeleteBehavior.Restrict); 
        }

    }
}