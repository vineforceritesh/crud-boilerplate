using System.ComponentModel.DataAnnotations;

namespace UserCrud.Student.Dto
{
    public class UpdateStudentDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        [Required]
        public int CollegeId { get; set; }
    }
}
