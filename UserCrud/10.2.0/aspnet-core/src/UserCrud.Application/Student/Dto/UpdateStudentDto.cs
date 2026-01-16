using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace UserCrud.Student.Dto
{
    public class UpdateStudentDto : EntityDto<int>
    {
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public int Age { get; set; }

        public string College { get; set; }

        public bool IsActive { get; set; }
    }
}
