using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserCrud.Student.Dto;
using UserCrud.Students;

namespace UserCrud.Student
{
    [AbpAuthorize]
    public class StudentAppService : ApplicationService, IStudentAppService
    {
        private readonly IRepository<Students.Student, int> _studentRepository;
        private readonly IRepository<Collage.Collage, int> _collegeRepository;

        public StudentAppService(
            IRepository<Students.Student, int> studentRepository,
            IRepository<Collage.Collage, int> collegeRepository)
        {
            _studentRepository = studentRepository;
            _collegeRepository = collegeRepository;
        }

        // ✅ Get All with College Name
        public async Task<List<StudentDto>> GetAllAsync()
        {
            var students = await _studentRepository
                .GetAll()
                .Include(x => x.College)
                .ToListAsync();

            var result = students.Select(x => new StudentDto
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Age = x.Age,
                CollegeId = x.CollegeId,
                CollegeName = x.College.Name
            }).ToList();

            return new List<StudentDto>(result);
        }

        // ✅ Create
        public async Task<StudentDto> CreateAsync(CreateStudentDto input)
        {
            var college = await _collegeRepository.FirstOrDefaultAsync(input.CollegeId);
            if (college == null)
                throw new UserFriendlyException("Invalid College");

            var student = ObjectMapper.Map<Students.Student>(input);

            await _studentRepository.InsertAsync(student);
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<StudentDto>(student);
        }


        // ✅ Update
        public async Task<StudentDto> UpdateAsync(UpdateStudentDto input)
        {
            var student = await _studentRepository.GetAsync(input.Id);

            var collegeExists = await _collegeRepository.FirstOrDefaultAsync(input.CollegeId);
            if (collegeExists == null)
                throw new UserFriendlyException("Invalid College");

            ObjectMapper.Map(input, student);
            await _studentRepository.UpdateAsync(student);

            return ObjectMapper.Map<StudentDto>(student);
        }

        public async Task DeleteAsync(EntityDto<int> input)
        {
            await _studentRepository.DeleteAsync(input.Id);
        }
    }
}
