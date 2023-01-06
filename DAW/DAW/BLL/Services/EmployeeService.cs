using AutoMapper;
using DAW.BLL.Interfaces;
using DAW.Common.DTOs.Employee;
using DAW.Common.Exceptions;
using DAW.DAL.Interfaces;
using DAW.Models;

namespace DAW.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task UpdateEmployee(int id,UpdateEmployeeDto updateEmployeeDto)
        {
            Employee employee = _mapper.Map<Employee>(updateEmployeeDto);
            employee.Id = id;
            _repository.Update(employee);
            await _repository.Save();
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            Employee employee = await _repository.FindById(id);
            if (employee is null)
                return false;
            _repository.Delete(employee);
            await _repository.Save();
            return true;
        }

        public async Task<UpdateEmployeeDto> FindById(int id)
        {
            var employee = await _repository.FindById(id);
            return _mapper.Map<UpdateEmployeeDto>(employee);
        }

        public async Task<List<EmployeeDto>> GetAvailable()
        {
            var employee = await _repository.GetAvailableList();
            if (employee is null)
                throw new NotFoundException($"There is no available employees");
            var employeeDto = _mapper.Map<List<EmployeeDto>>(employee);
            return employeeDto;
        }

        public async Task<List<EmployeeDto>> GetUnavailable()
        {
            var employee = await _repository.GetUnavailableList();
            if (employee is null)
                throw new NotFoundException($"All employees are available");
            var employeeDto = _mapper.Map<List<EmployeeDto>>(employee);
            return employeeDto;
        }
    }
}
