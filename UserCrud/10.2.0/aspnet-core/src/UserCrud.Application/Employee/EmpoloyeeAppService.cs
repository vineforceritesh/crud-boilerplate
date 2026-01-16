using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using UserCrud.Employee.Dto;
using UserCrud.Employee;

namespace UserCrud.Employee
{
    public class EmployeeAppService : ApplicationService, IEmployeeAppService
    {
        private readonly IRepository<Employee, int> _employeeRepository;

        public EmployeeAppService(IRepository<Employee, int> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            var employees = await _employeeRepository.GetAllListAsync();
            return ObjectMapper.Map<List<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto> CreateAsync(CreateEmployeeDto input)
        {
            var employee = ObjectMapper.Map<Employee>(input);
            var insertedEmployee = await _employeeRepository.InsertAsync(employee);
            return ObjectMapper.Map<EmployeeDto>(insertedEmployee);
        }

        public async Task<EmployeeDto> UpdateAsync(UpdateEmployeeDto input)
        {
            var employee = await _employeeRepository.FirstOrDefaultAsync(x => x.Id == input.Id);
            ObjectMapper.Map(input, employee);
            await _employeeRepository.UpdateAsync(employee);
            return ObjectMapper.Map<EmployeeDto>(employee);
        }

        public async Task DeleteAsync(int id)
        {
            await _employeeRepository.DeleteAsync(id);
        }
    }
}
