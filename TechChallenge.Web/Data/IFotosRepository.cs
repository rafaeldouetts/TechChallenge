using Microsoft.AspNetCore.Mvc;
using TechChallengeWeb.Models;

namespace TechChallengeWeb.Data
{
    public interface IFotosRepository
    {
        Task<Foto> AddFoto(Foto foto);
        void DeleteFoto(int id);
        Foto GetFoto(int id);
        IEnumerable<Foto> GetFotos();


    }
}
