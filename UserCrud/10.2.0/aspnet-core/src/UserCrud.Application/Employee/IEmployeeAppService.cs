using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserCrud.Employee.Dto;

namespace UserCrud.Employee
{
    public interface IEmployeeAppService : IApplicationService
    {
        Task<List<EmployeeDto>> GetAllAsync();

        Task<EmployeeDto> CreateAsync(CreateEmployeeDto input);

        Task<EmployeeDto> UpdateAsync(UpdateEmployeeDto input);

        Task DeleteAsync(int id);

    }
}
