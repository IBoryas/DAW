using DAW.Common.DTOs.Employee;
using DAW.Models;
using System.IO;

namespace DAW.BLL.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAvailable();
        Task<List<EmployeeDto>> GetUnavailable();
        Task<UpdateEmployeeDto> FindById(int id);
        Task UpdateEmployee(int id, UpdateEmployeeDto employeeDto);
        Task<bool> DeleteEmployee(int id);

    }
}
