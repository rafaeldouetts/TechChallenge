using TechChallengeWeb.Models;

namespace TechChallengeWeb.Data
{
    public interface IUsuarioRepository
    {
        Task<Usuario> AddUsuario(Usuario usuario);
        void DeleteUsuario(int id);
        Usuario GetUsuarioById(int id);
    }
}
