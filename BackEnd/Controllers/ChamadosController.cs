using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HelpDesk.Models;
using HelpDesk.ViewModel;
using HelpDesk.Repository;

namespace HelpDesk.Controllers 
{
    [ApiController]
    [Route("api/chamados")]
    public class ChamadosController : ControllerBase
    {
        private readonly IChamadoRepository _chamadoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public ChamadosController(IChamadoRepository chamadoRepository, IUsuarioRepository usuarioRepository)
        {
            _chamadoRepository = chamadoRepository ?? throw new ArgumentNullException(nameof(chamadoRepository));
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
        }

        // Método GET para buscar os chamados
        [HttpGet]
        public IActionResult GetChamados()
        {
            var chamados = _chamadoRepository.GetWithUsuarios();
            return Ok(chamados);
        }

        // Método GET para buscar um chamado específico por ID
        [HttpGet("{id}")]
        public IActionResult GetChamadoById(int id)
        {
            var chamado = _chamadoRepository.GetWithUsuarios().FirstOrDefault(c => c.Id == id);

            if (chamado == null)
            {
                return NotFound("Chamado não encontrado.");
            }

            return Ok(chamado);
        }

        // Método POST para criar um chamado
        [HttpPost]
        public async Task<IActionResult> CriarChamado([FromBody] ChamadoViewModel chamadoView)
        {
            // Debug: Verificar se o UsuarioId está chegando corretamente
            Console.WriteLine($"Chamado recebido para UsuarioId: {chamadoView.UsuarioId}");

            // Debug: Testar se os usuários estão sendo recuperados corretamente
            var usuarios = _usuarioRepository.Get().ToList();
            Console.WriteLine($"Usuários encontrados: {usuarios.Count}");

            foreach (var user in usuarios)
            {
                Console.WriteLine($"ID: {user.Id}, Nome: {user.Name}");
            }


            // Verificar se o usuário existe
            var usuario = _usuarioRepository.Get().FirstOrDefault(u => u.Id.ToString() == chamadoView.UsuarioId.ToString());
            if (usuario == null)
            {
                return BadRequest("Usuário não encontrado.");
            }

            // Criação do chamado com os dados fornecidos
            var chamado = new Chamados(
                chamadoView.Titulo,
                chamadoView.Descricao,
                chamadoView.UsuarioId,
                chamadoView.Status ?? "Aberto", // Se o status não for informado, assume o padrão "Aberto"
                chamadoView.Prioridade ?? "Média" // Se a prioridade não for informada, assume o padrão "Média"
            );

            // Adiciona o chamado ao repositório
            _chamadoRepository.Add(chamado);

            // Salva as mudanças no banco de dados de forma assíncrona
            await _chamadoRepository.SaveChangesAsync();

            // Retorna uma resposta 201 com o novo chamado criado
            return CreatedAtAction(nameof(GetChamados), new { id = chamado.Id }, chamado);
        }
    }
}
