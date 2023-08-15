using System.ComponentModel.DataAnnotations;

namespace TechChallenge.Identity.Models
{
	public class Usuario
	{
		
		public Usuario(string nome, string email, Guid id)
		{
			Id = id;
			Nome = nome;
			Email = email;
		}

		public Usuario(string nome, string email, Guid id, bool emailConfirmed)
		{
			Id = id;
			Nome = nome;
			Email = email;
			EmailConfirmed = emailConfirmed; 
		}

		public Guid Id { get; set; }
		public string Nome { get; set; }
		public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
    }
}
