using System.ComponentModel.DataAnnotations;

namespace TechChallengeWeb.Models
{
    public class Foto
    {
        public Foto(bool publica, string url)
        {
            Publica = publica;
            Url = url;
            DataEnvio = DateTime.Now;
        }

        [Key]
        [Required]
        public int Id { get; set; }
        public bool Publica { get; set; }
        public string Url { get; set; }
        public DateTime DataEnvio { get; set; }
    }
}
