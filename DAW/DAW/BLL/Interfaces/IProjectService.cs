using DAW.Common.DTOs.Deals;
using DAW.Common.DTOs.Project;

namespace DAW.BLL.Interfaces
{
    public interface IProjectService
    {
        Task<List<ListProjectDto>> GetList();
        Task<List<ListProjectDto>> GetAvailable();
        Task Add(AddProjectDto projectDto);
        Task<List<ProjectDto>> GetAll();
        Task Delete(int id);
        Task Update(int id, UpdateProjectDto projectDto);
    }
}
