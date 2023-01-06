using DAW.Models;

namespace DAW.DAL.Interfaces
{
    public interface IDealRepository
    {
        Task Add(Deal client);
        Task Save();
        Task<List<Deal>> GetAll();
        void Delete(Deal client);
        Task<Deal> FindById(int id);
    }
}
