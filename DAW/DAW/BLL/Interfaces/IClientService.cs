using DAW.Common.DTOs.Client;

namespace DAW.BLL.Interfaces
{
    public interface IClientService
    {
        Task Add(CreateClientDto clientDto);
        Task<List<ClientDto>> GetAll();
        Task Delete(int id);
        Task Update(int id, UpdateClientDto clientDto);
        Task<List<ListCLientDto>> GetList();
    }
}
