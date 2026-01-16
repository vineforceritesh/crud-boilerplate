using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCrud.Student.Dto
{
    public class StudentDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string College { get; set; }
    }
}
