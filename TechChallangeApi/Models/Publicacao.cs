using System.ComponentModel.DataAnnotations;

namespace TechChallangeApi.Models
{
    public class Publicacao
    {
        public Publicacao()
        {
        }
        public Publicacao(string nome, Usuario usuario, Foto foto)
        {
            Nome = nome;
            Usuario = usuario;
            //UrlPerfil = urlPerfil;
            Foto = foto;
            DataEnvio = DateTime.Now;
        }

        [Key]
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
        public Usuario Usuario { get; set; }
        //public string UrlPerfil { get; set; }
        public Foto Foto { get; set; }
        public DateTime DataEnvio { get; set; }
    }
}
