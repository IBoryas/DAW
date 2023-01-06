using AutoMapper;
using DAW.Common.DTOs.Employee;
using DAW.Models;

namespace DAW.BLL.Profiles
{
    public class EmployeeProfile: Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(x => x.ProjectName, y => y.MapFrom(z=>z.Project.Name));

            CreateMap<UpdateEmployeeDto, Employee>();
            CreateMap<Employee, UpdateEmployeeDto>();
        }
    }
}
