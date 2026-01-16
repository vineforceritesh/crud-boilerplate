using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserCrud.Authorization;
using UserCrud.Student.Dto;
using UserCrud.Students;

namespace UserCrud.Student
{
    [AbpAuthorize]
    public class StudentAppService : ApplicationService, IStudentAppService
    {
        private readonly IRepository<Students.Student, int> _studentRepository;

        public StudentAppService(IRepository<Students.Student, int> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<StudentDto>> GetAllAsync()
        {
            var students = await _studentRepository.GetAllListAsync();
            var data =  ObjectMapper.Map<List<StudentDto>>(students);
            return data;
        }

        public async Task<Students.Student> CreateAsync(CreateStudentDto input)
        {
            var student = ObjectMapper.Map<Students.Student>(input);
            var data = await _studentRepository.InsertAsync(student);
            return data;
        }

        public async Task<Students.Student> UpdateAsync(UpdateStudentDto input)
        {
            var student = await _studentRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, student);
          return await _studentRepository.UpdateAsync(student);
           
        }

        public async Task DeleteAsync(EntityDto<int> input)
        {
            await _studentRepository.DeleteAsync(input.Id);
        }
    }
}
