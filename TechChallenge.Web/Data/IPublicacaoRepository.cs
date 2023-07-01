using TechChallengeWeb.Models;

namespace TechChallengeWeb.Data
{
    public interface IPublicacaoRepository
    {
        Task<Publicacao> AddPublicacao(Publicacao publicacao);
        void DeletePublicacao(int id);
        Publicacao GetPublicacaoById(int id);
        Publicacao GetPublicacaoByUsuarioEData(Usuario usuario, DateTime dateTime);
        IEnumerable<Publicacao> GetPublicacoes(Usuario usuario);
    }
}
