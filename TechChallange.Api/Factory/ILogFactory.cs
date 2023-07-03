using System.Net;
using TechChallenge.Api.Models;
using TechChallenge.Api.Service;

namespace TechChallenge.Api.Factory
{
	public interface ILogFactory
	{
		string Create(string url, HttpMethod httpMethod, object conteudo, Guid usuarioId, HttpStatusCode statusCode);
		string Create(string url, HttpMethod httpMethod, object conteudo, Guid usuarioId);
	}
}
