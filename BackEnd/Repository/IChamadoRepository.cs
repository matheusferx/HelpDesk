using System.Collections.Generic;
using HelpDesk.Models;

namespace HelpDesk.Repository
{
    public interface IChamadoRepository 
    {
        void Add(Chamados chamado);
        List<Chamados> GetWithUsuarios();
        Task SaveChangesAsync();

    }
}