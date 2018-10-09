namespace CNet.App.Core
{
    using AutoMapper;
    using Dtos;
    using Models;

    public class CNetProfile : Profile
    {
        public CNetProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();

            CreateMap<Employee, EmployeePersonalInfoDto>().ReverseMap();

            CreateMap<Employee, ManagerDto>()
                .ForMember(dest => dest.EmployeeDtos, from => from.MapFrom(x => x.ManagerEmployees))
                .ReverseMap();

            CreateMap<Employee, EmployeeByAgeDto>()
                .ForMember(dest => dest.ManagerDto, from => from.MapFrom(x => x.Manager))
                .ReverseMap();
        }
    }
}
