using System.ComponentModel.DataAnnotations;

namespace TechChallangeApi.Models
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
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Publicacao> Publicacoes { get; set; }     
    }
}
