using System.ComponentModel.DataAnnotations;

namespace TechChallengeWeb.Models
{
    public class Usuario
    {
        public Usuario(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        [Key]
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
