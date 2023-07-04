namespace TechChallenge.Api.Models
{
	public class Log
	{
		public Log(string url, string httpMethod, DateTime data, string conteudo, Guid usuarioid)
		{
			Url = url;
			HttpMethod = httpMethod;
			Data = data;
			Conteudo = conteudo;
			Usuarioid = usuarioid;
		}

		public Log(string url, string httpMethod, DateTime data, string conteudo, Guid usuarioid, int? statusCode)
		{
			Url = url;
			HttpMethod = httpMethod;
			Data = data;
			Conteudo = conteudo;
			Usuarioid = usuarioid;
			StatusCode = statusCode;
		}

		string Url { get; set; }
		string HttpMethod { get; set; }
		DateTime Data { get; set; }
		string Conteudo { get; set; }
		Guid Usuarioid { get; set; }
		int? StatusCode { get; set; }
	}
}
