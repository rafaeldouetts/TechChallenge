using Microsoft.EntityFrameworkCore;
using TechChallangeApi.Models;

namespace TechChallangeApi.Data
{
    public class UsuarioRepository : IUsuarioRepository
    {

        public ApplicationContext context;

        public UsuarioRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task AddUsuario(Usuario usuario)
        {
            try
            {
                var result = await context.Set<Usuario>().AddAsync(usuario);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteUsuario(Guid id)
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

        public Usuario GetUsuarioById(Guid id)
        {
            try
            {
                //Usuario usuarioResultado = context.Usuarios.FirstOrDefault(u => u.Id == id);
                //if (usuarioResultado == null) throw new Exception("Usuario não encontrada");
                //return usuarioResultado;

                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
