using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using TechChallangeApi.Data;
using TechChallangeApi.Models;
using TechChallengeApi.Models;

namespace TechChallangeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PubliController : ControllerBase
    {

        private readonly ILogger<PubliController> _logger;
        private readonly IPublicacaoRepository _publicacaoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly FotoController _fotoController;

        public PubliController(ILogger<PubliController> logger, IPublicacaoRepository publicacaoRepository, IUsuarioRepository usuarioRepository, FotoController fotoController)
        {
            _logger = logger;
            _publicacaoRepository = publicacaoRepository;
            _usuarioRepository = usuarioRepository;
            _fotoController = fotoController;
        }

        [HttpGet("{usuarioId}")]
        [SwaggerOperation(Summary = "Publicações do usuário", Description = "Retorna Lista com todas as publicações do usuário que possue o ID informado")]
        public IActionResult PublicacoesByUserId(Guid usuarioId)
        {
            Usuario usuario = _usuarioRepository.GetUsuarioById(usuarioId);
            IEnumerable<Publicacao> publicacoes = _publicacaoRepository.GetPublicacoes(usuario);

            return Ok(publicacoes);

        }

        [HttpPost("{usuarioId}/Date")]
        [SwaggerOperation(Summary = "Publicação do usuário em data específica", Description = "Retorna Lista com todas as publicações na data informada e publicadas pelo usuário que possue o ID informado")]
        public IActionResult PublicacoesByUserIdAndDate(Guid usuarioId, [FromBody] string date)
        {
            Usuario usuario = _usuarioRepository.GetUsuarioById(usuarioId);

            DateTime dataComparacao = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            IEnumerable<Publicacao> publicacoes = _publicacaoRepository.GetPublicacoes(usuario).Where(p => p.DataEnvio.Date.CompareTo(dataComparacao.Date) == 0) ;

            return Ok(publicacoes);

        }
        //string nome, Usuario usuario, string urlPerfil, Foto foto
        [HttpPost("New")]
        [SwaggerOperation(Summary = "Fazer uma publicação", Description = "Envia uma foto para ser registrada no storage e no DB com as informações do usuário")]
        public async Task<IActionResult> NewPublicacao(PuclicacaoInsert puclicacao)
        {
			var idUsuario = new Guid("DDECCA19-CB4B-4E49-81B3-DC4B16CC060E");
		
            Publicacao publicacao = await _publicacaoRepository.AddPublicacao(new Publicacao(puclicacao.Nome, idUsuario, puclicacao.FotoId));


            return NoContent();

            //var okResult = Ok(result) as OkObjectResult;
            //if (okResult == null) return NoContent();

            //var json = JsonConvert.SerializeObject(okResult.Value,Formatting.Indented);
            //Foto foto = JsonConvert.DeserializeObject<Foto>(json);

            //Publicacao publicacao = await _publicacaoRepository.AddPublicacao(new Publicacao(nome, usuario, foto));
            //if (publicacao == null) return NoContent();
            //return Ok(publicacao);

        }

		private Guid obterUsuarioId()
		{
			return new Guid(User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
		}
	}
}