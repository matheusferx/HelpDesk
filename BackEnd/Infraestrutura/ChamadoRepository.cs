using HelpDesk.Models;
using HelpDesk.Repository;
using HelpDesk.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Infraestrutura
{
    public class ChamadoRepository : IChamadoRepository
    {
        private readonly ConnectionContext _context;

        public ChamadoRepository(DbContextOptions<ConnectionContext> options)
        {
            _context = new ConnectionContext(options);
        }

        public void Add(Chamados chamado)
        {
            _context.Chamados.Add(chamado);
            _context.SaveChanges();
        }

        public List<Chamados> GetWithUsuarios()
        {
            return _context.Chamados.Include(c => c.UsuarioId).ToList();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}