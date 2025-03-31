using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HelpDesk.Models;

namespace HelpDesk.Models 
{
    public class Chamados
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        public int UsuarioId { get; private set; }

        [ForeignKey("UsuarioId")]
        public Usuarios? Usuario { get; private set; }

        [Required, StringLength(100)]
        public string Titulo { get; private set; } = string.Empty;

        [Required, StringLength(500)]
        public string Descricao { get; private set; } = string.Empty;

        [Required]
        public string Status { get; private set; } = "Aberto"; // Aberto, Em andamento, Fechado

        [Required]
        public string Prioridade { get; private set; } = "Média"; // Baixa, Média, Alta

        [Required]
        public DateTime DataCriacao { get; private set; } = DateTime.UtcNow;

        public Chamados() { }

        public Chamados(string titulo, string descricao, int usuarioId, string status = "Aberto", string prioridade = "Média")
        {
            if (string.IsNullOrWhiteSpace(titulo)) throw new ArgumentException("Título não pode ser vazio.");
            if (string.IsNullOrWhiteSpace(descricao)) throw new ArgumentException("Descrição não pode ser vazia.");

            UsuarioId = usuarioId;
            Titulo = titulo;
            Descricao = descricao;
            Status = status;
            Prioridade = prioridade;
        }
    }
}
