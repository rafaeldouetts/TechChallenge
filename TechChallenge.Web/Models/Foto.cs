using System.ComponentModel.DataAnnotations;

namespace TechChallengeWeb.Models
{
    public class Foto
    {
        public Foto(bool publica, string url, string extensao)
        {
            Publica = publica;
            Url = url;
            Extensao = extensao;
            DataEnvio = DateTime.Now;
        }

        [Key]
        [Required]
        public int Id { get; set; }
        public bool Publica { get; set; }
        public string Url { get; set; }
        public string Extensao { get; set; }
        public DateTime DataEnvio { get; set; }
    }
}
