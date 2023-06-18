using Azure.Messaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using TechChallangeApi.Data;
using TechChallangeApi.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace TechChallangeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FotoController : ControllerBase
    {
        private readonly ILogger<FotoController> _logger;
        private readonly IFotosRepository _fotoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly HttpClient _httpClient;

        public FotoController(ILogger<FotoController> logger, IFotosRepository fotoRepository, IUsuarioRepository usuarioRepository, HttpClient httpClient)
        {
            _logger = logger;
            _fotoRepository = fotoRepository;
            _usuarioRepository = usuarioRepository;
            _httpClient = httpClient;
        }

        [HttpGet("Id")]
        [SwaggerOperation(Summary = "Foto por Id", Description = "Retorna a foto respectiva do Id")]
        public IActionResult FotoById(int id)
        {
            Foto publicacoes = _fotoRepository.GetFoto(id);

            return Ok(publicacoes);

        }

        [HttpPost]
        [SwaggerOperation(Summary = "Salvar foto", Description = "Solicita a criação da foto no Storage e salva informações no DB")]
        public async Task<IActionResult> NewFoto(IFormFile formFile)
        {
            // Criar uma requisição HTTP POST com o corpo e cabeçalhos desejados
            
            var requestURLPost = "http://localhost:5012/Upload";

            // Adicione o conteúdo do arquivo ao HttpContent
            var fileContent = new StreamContent(formFile.OpenReadStream());
            var content = new MultipartFormDataContent();
            content.Add(fileContent, "formFile", formFile.FileName);

            // Defina o cabeçalho "Content-Type" usando o HttpContent
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(formFile.ContentType);

            // Enviar a requisição e obter a resposta
            HttpResponseMessage responsePost = await _httpClient.PostAsync(requestURLPost, content);
            if (!responsePost.IsSuccessStatusCode) return NoContent();
            string resultPost = await responsePost.Content.ReadAsStringAsync();

            var requestURLGet = "http://localhost:5012/GetSpecific";

            var requestURLGetString = requestURLGet + "?blobName=" + resultPost.Substring(1, resultPost.Length - 2);

            HttpResponseMessage responseGet = await _httpClient.GetAsync(requestURLGetString);
            if (!responseGet.IsSuccessStatusCode) return NoContent();
            string responseGetString = await responseGet.Content.ReadAsStringAsync();
            string url = responseGetString.Substring(1, responseGetString.IndexOf('?'));

            string extensao = Path.GetExtension(fileContent.Headers.ContentDisposition.FileName);

            Foto fotoResult = await _fotoRepository.AddFoto(new Foto(true, url, extensao));
            if(fotoResult == null) return NoContent();
            return Ok(fotoResult);

        }

        //[HttpPost("Id/Date/{usuarioId}")]
        //[SwaggerOperation(Summary = "Publicação do usuário em data específica", Description = "Retorna Lista com todas as publicações na data informada e publicadas pelo usuário que possue o ID informado")]
        //public IActionResult PublicacoesByUserIdAndDate(int usuarioId, [FromBody] string date)
        //{
        //    Usuario usuario = _usuarioRepository.GetUsuarioById(usuarioId);

        //    DateTime dataComparacao = DateTime.Parse(date);

        //    IEnumerable<Publicacao> publicacoes = _fotoRepository.GetPublicacoes(usuario).Where(p => p.DataEnvio.Date.CompareTo(dataComparacao.Date) == 0) ;

        //    return Ok(publicacoes);

        //}

    }
}