using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HelpDesk.Models {

    public class Usuarios {
        
        [Key]
        public int Id  {get; private set;}

        [Required, StringLength(10)]
        public string Name {get; private set;} = string.Empty;

        [Required]
        public string SenhaHash {get; private set;} = string.Empty;

        [Required]
        public int Age { get; private set; }

        [Required, StringLength(50)]
        public string Email {get; private set;} = string.Empty;

        [Required]
        public string TipoUsuario {get; private set;} = "Usuario";

        public Usuarios() {}

        public Usuarios(string name, string senhahash, int age, string email, string tipoUsuario) {

            Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentException("Nome não pode ser vazio.") : name;
            
            SenhaHash = string.IsNullOrWhiteSpace(senhahash) ? throw new ArgumentException("Senha não pode ser vazia.") : senhahash;
            
            Email = string.IsNullOrWhiteSpace(email) ? throw new ArgumentException("Email não pode ser vazio.") : email;
            
            Age = age;

            TipoUsuario = tipoUsuario;
        }

        public ICollection<Chamados> Chamados { get; set; } = new List<Chamados>();
    }
}