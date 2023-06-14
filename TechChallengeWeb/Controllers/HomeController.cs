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
        private readonly IUsuarioRepository _usuarioRepository;

        public HomeController(ILogger<HomeController> logger, IPublicacaoRepository publicacaoRepository, IUsuarioRepository usuarioRepository)
        {
            _logger = logger;
            _publicacaoRepository = publicacaoRepository;
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Publicacoes()
        {
            Usuario usuario = _usuarioRepository.GetUsuarioById(1);
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