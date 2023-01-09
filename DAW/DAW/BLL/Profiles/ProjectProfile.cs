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
            CreateMap<Project, ProjectDto>()
                .ForMember(
                    x => x.Employees,
                    y => y.MapFrom(z => z.Employees.Select(d => $"{d.LastName} {d.FirstName} - {d.JobRole}")));
            CreateMap<UpdateProjectDto, Project>();
        }
    }
}
