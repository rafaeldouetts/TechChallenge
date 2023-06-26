using System.ComponentModel.DataAnnotations;

namespace TechChallangeApi.Models
{
    public class Foto
    {
        public Foto(bool publica, string url, string extensao, Guid usuarioId)
        {
            Publica = publica;
            Url = url;
            Extensao = extensao;
            DataEnvio = DateTime.Now;
			UsuarioId = usuarioId;
        }

        [Key]
        [Required]
        public int Id { get; set; }
        public bool Publica { get; set; }
        public string Url { get; set; }
        public string Extensao { get; set; }
        public DateTime DataEnvio { get; set; }
        public Guid UsuarioId { get; set; }       
    }
}
