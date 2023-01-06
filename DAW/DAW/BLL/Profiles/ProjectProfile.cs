using AutoMapper;
using DAW.Common.DTOs.Employee;
using DAW.Common.DTOs.Project;
using DAW.Models;

namespace DAW.BLL.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ListProjectDto>();
            CreateMap<AddProjectDto, Project>();
            CreateMap<Project, ProjectDto>();
            CreateMap<UpdateProjectDto, Project>();
        }
    }
}
