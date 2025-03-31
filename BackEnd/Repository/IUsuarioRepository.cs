using System.Collections.Generic;
using HelpDesk.Models;

namespace HelpDesk.Repository {

    public interface IUsuarioRepository {
         
        void Add(Usuarios Usuario);
        List<Usuarios> Get();
    }
}