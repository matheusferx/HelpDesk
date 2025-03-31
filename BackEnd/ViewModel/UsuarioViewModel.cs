using System.ComponentModel.DataAnnotations;

namespace HelpDesk.ViewModel {

    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string SenhaHash { get; set; } = string.Empty;

        [Required(ErrorMessage = "A idade é obrigatória.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O tipo de usuário é obrigatório.")]
        public string TipoUsuario { get; set; } = "Usuario";
    }

}