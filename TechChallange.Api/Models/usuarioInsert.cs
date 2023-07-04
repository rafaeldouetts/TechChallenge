using System.ComponentModel.DataAnnotations;

namespace TechChallenge.Api.Models
{
	public class usuarioInsert
	{
		[Required]
		public Guid Id { get; set; }
		[Required]
		public string Nome { get; set; }
		[Required]
		public string Email { get; set; }
	}
}
