using Microsoft.AspNetCore.Mvc;
using TechChallangeApi.Models;

namespace TechChallangeApi.Data
{
    public interface IFotosRepository
    {
        Task<Foto> AddFoto(Foto foto);
        void DeleteFoto(int id);
        Foto GetFoto(int id);
        IEnumerable<Foto> GetFotos();


    }
}
