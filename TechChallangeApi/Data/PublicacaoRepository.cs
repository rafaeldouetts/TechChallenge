using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechChallangeApi.Models;

namespace TechChallangeApi.Data
{
    public class PublicacaoRepository : IPublicacaoRepository
    {

        public ApplicationContext context;

        public PublicacaoRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<Publicacao> AddPublicacao(Publicacao publicacao)
        {
            try
            {
                if (publicacao == null) throw new ArgumentNullException(nameof(publicacao));
                await context.Set<Publicacao>().AddAsync(publicacao);
                await context.SaveChangesAsync();
                return publicacao;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeletePublicacao(int id)
        {
            try
            {
                Publicacao publicacaoResultado = GetPublicacaoById(id);
                if (publicacaoResultado == null) throw new ArgumentNullException(nameof(id));
                context.Set<Publicacao>().Remove(publicacaoResultado);
                context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Publicacao GetPublicacaoById(int id)
        {
            try
            {

                Publicacao publicacaoResultado = context.Publicacoes.FirstOrDefault(p => p.Id == id);
                if (publicacaoResultado == null) throw new Exception("Publicação não encontrada");
                return publicacaoResultado;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Publicacao GetPublicacaoByUsuarioEData(Usuario usuario, DateTime dateTime)
        {
            try
            {

                Publicacao publicacaoResultado = context.Publicacoes.FirstOrDefault(p => p.Usuario == usuario && p.DataEnvio == dateTime);
                if (publicacaoResultado == null) throw new Exception("Publicação não encontrada");
                return publicacaoResultado;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Publicacao> GetPublicacoes(Usuario usuario)
        {
            try
            {
                IEnumerable<Publicacao> publicacoesResultado = context.Publicacoes.Where(p => p.Usuario == usuario);
                if (publicacoesResultado == null) throw new Exception("Publicações não encontradas para esse usuário");
                return publicacoesResultado;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
