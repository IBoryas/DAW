using DAW.Common.DTOs.Client;
using DAW.Common.DTOs.Deals;

namespace DAW.BLL.Interfaces
{
    public interface IDealService
    {
        Task Add(CreateDealDto clientDto);
        Task<List<DealDto>> GetAll();
        Task Delete(int id);
        Task Update(int id, UpdateDealDto dealDto);
    }
}
