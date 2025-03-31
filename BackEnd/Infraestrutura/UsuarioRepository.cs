using HelpDesk.Models;
using HelpDesk.Repository;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Infraestrutura
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ConnectionContext _context;

        public UsuarioRepository(DbContextOptions<ConnectionContext> options)
        {
            _context = new ConnectionContext(options);
        }

        public void Add(Usuarios usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public List<Usuarios> Get()
        {
            return _context.Usuarios.ToList();
        }
    }
}