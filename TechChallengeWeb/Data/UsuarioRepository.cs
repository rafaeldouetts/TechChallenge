using Microsoft.EntityFrameworkCore;
using TechChallengeWeb.Models;

namespace TechChallengeWeb.Data
{
    public class UsuarioRepository : IUsuarioRepository
    {

        public ApplicationContext context;

        public UsuarioRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<Usuario> AddUsuario(Usuario usuario)
        {
            try
            {
                if (usuario == null) throw new ArgumentNullException(nameof(usuario));
                await context.Set<Usuario>().AddAsync(usuario);
                await context.SaveChangesAsync();
                Usuario usuarioResultado = await context.Usuarios.FirstOrDefaultAsync(u => u.Id == usuario.Id);
                if (usuarioResultado == null) throw new Exception("Usuario não encontrada");
                return usuarioResultado;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteUsuario(int id)
        {
            try
            {
                Usuario usuarioResultado = GetUsuarioById(id);
                if (usuarioResultado == null) throw new Exception("Usuario não encontrada");
                context.Set<Usuario>().Remove(usuarioResultado);
                context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Usuario GetUsuarioById(int id)
        {
            try
            {
                Usuario usuarioResultado = context.Usuarios.FirstOrDefault(u => u.Id == id);
                if (usuarioResultado == null) throw new Exception("Usuario não encontrada");
                return usuarioResultado;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
