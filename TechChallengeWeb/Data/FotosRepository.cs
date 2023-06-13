using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechChallengeWeb.Models;

namespace TechChallengeWeb.Data
{
    public class FotosRepository : IFotosRepository
    {

        public ApplicationContext context;

        public FotosRepository(ApplicationContext context)
        {
            this.context = context;
        }

        async Task<Foto> IFotosRepository.AddFoto(Foto foto)
        {
            try
            {
                if (foto == null) throw new ArgumentNullException(nameof(foto));
                await context.Set<Foto>().AddAsync(foto);
                await context.SaveChangesAsync();
                Foto fotoResultado = await context.Fotos.FirstOrDefaultAsync(f => f.Id == foto.Id);
                if (fotoResultado == null) throw new Exception("Foto não encontrada");
                return fotoResultado;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteFoto(int id)
        {
            try
            {
                Foto foto = GetFoto(id);
                if (foto == null)
                context.Fotos.Remove(foto);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Foto GetFoto(int id)
        {
            try 
            {
                Foto foto = context.Fotos.FirstOrDefault(f => f.Id == id);
                if (foto == null) throw new Exception("Foto não encontrada");
                return foto;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Foto> GetFotos()
        {
            try
            {
                IEnumerable<Foto> fotos = context.Fotos;
                return fotos;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
