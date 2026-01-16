using Abp.Application.Services;
using Abp.Application.Services.Dto;
using UserCrud.Student.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserCrud.Student
{
    public interface IStudentAppService : IApplicationService
    {
        Task<List<StudentDto>> GetAllAsync();
        Task<Students.Student> CreateAsync(CreateStudentDto input);
        Task<Students.Student> UpdateAsync(UpdateStudentDto input);
        Task DeleteAsync(EntityDto<int> input);
    }
}
