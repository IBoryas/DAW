using DAW.Models;

namespace DAW.DAL.Interfaces
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAll();
        Task<List<Project>> GetAvailable();
        Task Add(Project project);
        Task Save();
        void Delete(Project project);
        Task<Project> FindById(int id);
    }
}
