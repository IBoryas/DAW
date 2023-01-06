using DAW.Models;

namespace DAW.DAL.Interfaces
{
    public interface IClientRepository
    {
        Task Add(Client client);
        Task Save();
        Task<List<Client>> GetAll();
        void Delete(Client client);
        Task<Client> FindById(int id);
    }
}
