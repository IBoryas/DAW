using DAW.DAL.Interfaces;
using DAW.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace DAW.DAL.Repositories
{
    public class ProjectRepository: IProjectRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Project> _projects;

        public ProjectRepository(DbContext context)
        {
            _context = context;
            _projects = _context.Set<Project>();
        }

        public async Task Add(Project project)
        {
            await _projects.AddAsync(project);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<Project>> GetAll()
        {
            return await _projects.ToListAsync();
        }

        public async Task<List<Project>> GetAvailable()
        {
            return await _projects.Where(p => p.Deals == null).ToListAsync();
        }

        public void Delete(Project project)
        {
            _projects.Remove(project);
        }

        public async Task<Project> FindById(int id)
        {
            return await _projects.FindAsync(id);
        }
    }
}
