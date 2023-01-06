using DAW.Models;

namespace DAW.DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAvailableList();
        Task<List<Employee>> GetUnavailableList();
        Task<Employee> FindById(int id);
        void Update(Employee entity);
        void Delete(Employee entity);
        Task Save();
    }
}
