using Newtonsoft.Json;
using System;
using System.Net;
using TechChallenge.Api.Factory;
using TechChallenge.Api.Models;

namespace TechChallenge.Api.Service
{
	public class LogFactory : ILogFactory
	{
		public string Create(string url, HttpMethod httpMethod, object conteudo, Guid usuarioId)
		{
			Log teste = new Log(url, httpMethod.ToString(), DateTime.UtcNow, JsonConvert.SerializeObject(conteudo), usuarioId);
			
			var dsdd = JsonConvert.SerializeObject(new Log(url, httpMethod.ToString(), DateTime.UtcNow, JsonConvert.SerializeObject(conteudo), usuarioId));
			var dsdsd = JsonConvert.SerializeObject(teste);

			return JsonConvert.SerializeObject(new Log(url, httpMethod.ToString(), DateTime.UtcNow, JsonConvert.SerializeObject(conteudo), usuarioId));
		}

		public string Create(string url, HttpMethod httpMethod, object conteudo, Guid usuarioId, HttpStatusCode statusCode)
		{
			return JsonConvert.SerializeObject(new Log(url, httpMethod.ToString(), DateTime.UtcNow, JsonConvert.SerializeObject(conteudo), usuarioId, (int)statusCode));
		}
	}
}

