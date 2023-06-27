using TechChallangeApi.Models;

namespace TechChallangeApi.Data
{
    public interface IUsuarioRepository
    {
        Task<Usuario> AddUsuario(Usuario usuario);
        void DeleteUsuario(Guid id);
        Usuario GetUsuarioById(Guid id);
    }
}
