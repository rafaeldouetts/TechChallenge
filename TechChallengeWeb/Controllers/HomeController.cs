using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechChallengeWeb.Data;
using TechChallengeWeb.Models;

namespace TechChallengeWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPublicacaoRepository _publicacaoRepository;

        public HomeController(ILogger<HomeController> logger, IPublicacaoRepository publicacaoRepository)
        {
            _logger = logger;
            _publicacaoRepository = publicacaoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Publicacoes()
        {

            Usuario usuario = new Usuario("Mateus", "mateus@email.com");
            Foto foto = new Foto(true, "https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png");
            Publicacao publicacao = new Publicacao("Test publicacao", usuario, "www.com", foto);
            IEnumerable<Publicacao> viewModel = _publicacaoRepository.GetPublicacoes(usuario);
            return View(viewModel);

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}