using DAW.DAL.Interfaces;
using DAW.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace DAW.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Employee> _employees;

        public EmployeeRepository(DbContext context)
        {
            _context = context;
            _employees = _context.Set<Employee>();
        }

        public void Update(Employee entity)
        {
            _employees.Update(entity);
        }

        public void Delete(Employee entity)
        {
            _employees.Remove(entity);
        }

        public async Task<Employee> FindById(int id)
        {
            return await _employees.FindAsync(id);
        }

        public async Task<List<Employee>> GetAvailableList()
        {
            return await _employees.Where(e => e.Project == null).ToListAsync();
        }

        public async Task<List<Employee>> GetUnavailableList()
        {
            return await _employees.Where(e => e.Project != null).ToListAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
