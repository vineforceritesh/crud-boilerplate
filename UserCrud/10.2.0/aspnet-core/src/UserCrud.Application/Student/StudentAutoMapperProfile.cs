using AutoMapper;
using UserCrud.Student.Dto;
using UserCrud.Students;

public class StudentMapProfile : Profile
{
    public StudentMapProfile()
    {
        CreateMap<CreateStudentDto, Student>();
        CreateMap<UpdateStudentDto, Student>();
        CreateMap<Student, StudentDto>();
    }
}
