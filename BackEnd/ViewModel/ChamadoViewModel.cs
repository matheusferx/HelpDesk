using System.ComponentModel.DataAnnotations;

namespace HelpDesk.ViewModel {

    public class ChamadoViewModel {
        public int UsuarioId {get; private set;}
        
        public string Titulo {get; private set;} = string.Empty;

        public string Descricao {get; private set;} = string.Empty;

        public string Status {get; private set;} = "Aberto";

        public string Prioridade {get; private set;} = "Média"; 

        public DateTime DataCriacao {get; private set;} = DateTime.UtcNow;
    }
}