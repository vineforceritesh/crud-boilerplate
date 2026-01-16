using AutoMapper;
using UserCrud.Employee.Dto;
using UserCrud.Employee;

namespace UserCrud.Employee
{
    public class EmployeeAutoMapperProfile : Profile
    {
        public EmployeeAutoMapperProfile()
        {
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();
            CreateMap<Employee, EmployeeDto>();
        }
    }
}
