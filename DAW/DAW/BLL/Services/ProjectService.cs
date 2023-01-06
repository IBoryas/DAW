using AutoMapper;
using DAW.BLL.Interfaces;
using DAW.Common.DTOs.Deals;
using DAW.Common.DTOs.Project;
using DAW.DAL.Interfaces;
using DAW.Models;

namespace DAW.BLL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ListProjectDto>> GetList()
        {
            var projects = await _repository.GetAll();
            return _mapper.Map<List<ListProjectDto>>(projects);
        }

        public async Task<List<ListProjectDto>> GetAvailable()
        {
            var projects = await _repository.GetAvailable();
            return _mapper.Map<List<ListProjectDto>>(projects);
        }

        public async Task Add(AddProjectDto projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);
            await _repository.Add(project);
            await _repository.Save();
        }

        public async Task Delete(int id)
        {
            var project = await _repository.FindById(id);
            _repository.Delete(project);
            await _repository.Save();
        }

        public async Task<List<ProjectDto>> GetAll()
        {
            var projects = await _repository.GetAll();
            return _mapper.Map<List<ProjectDto>>(projects);
        }

        public async Task Update(int id, UpdateProjectDto projectDto)
        {
            var project = await _repository.FindById(id);
            _mapper.Map(projectDto, project);
            await _repository.Save();
        }
    }
}
