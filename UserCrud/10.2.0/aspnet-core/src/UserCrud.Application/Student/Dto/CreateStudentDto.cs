using System.ComponentModel.DataAnnotations;

namespace UserCrud.Student.Dto
{
    public class CreateStudentDto
    {
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public int Age { get; set; }

        [Required]
        public int CollegeId { get; set; }   // ✅ FK
    }
}
