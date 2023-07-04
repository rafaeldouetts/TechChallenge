using TechChallangeApi.Models;

namespace TechChallangeApi.Data
{
    public interface IUsuarioRepository
    {
        Task AddUsuario(Usuario usuario);
        void DeleteUsuario(Guid id);
        Usuario GetUsuarioById(Guid id);
    }
}
