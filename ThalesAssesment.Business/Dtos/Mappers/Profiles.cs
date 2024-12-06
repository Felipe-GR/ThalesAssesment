using AutoMapper;
using ThalesAssesment.Model.Entities;

namespace ThalesAssesment.Business.Dtos.Mappers
{
    internal class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(
                    dest => dest.Name,
                    src => src.MapFrom(s => s.EmployeeName)
                )
                .ForMember(
                    dest => dest.Salary,
                    src => src.MapFrom(s => s.EmployeeSalary)
                )
                .ForMember(
                    dest => dest.Age,
                    src => src.MapFrom(s => s.EmployeeAge)
                )
                .ForMember(
                    dest => dest.ProfileImage,
                    src => src.MapFrom(s => s.ProfileImage)
                )
                .ForMember(
                    dest => dest.AnualSalary,
                    src => src.MapFrom(s => s.EmployeeSalary * 12)
                )
                .ReverseMap();
        }
    }
}
