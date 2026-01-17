using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCrud.Student.Dto;

namespace UserCrud.Student
{
    public class StudentAutoMapperProfile : Profile
    {
        public StudentAutoMapperProfile()

        {   
            CreateMap<CreateStudentDto, Students.Student>();
           

            CreateMap<UpdateStudentDto, Students.Student>();

            CreateMap<Students.Student, StudentDto>();

        }
    }
}
