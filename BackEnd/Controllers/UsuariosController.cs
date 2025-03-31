using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HelpDesk.Models;
using HelpDesk.ViewModel;
using HelpDesk.Repository;

namespace HelpDesk.Controllers {

    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase{

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository) {
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
        }

        [HttpPost]
        public IActionResult Add([FromBody]UsuarioViewModel usuarioView) 
        {
            var usuarios = new Usuarios(usuarioView.Name, usuarioView.SenhaHash, usuarioView.Age, usuarioView.Email, usuarioView.TipoUsuario);
            _usuarioRepository.Add(usuarios);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var usuarios = _usuarioRepository.Get();
            return Ok(usuarios);
        }
    }
}