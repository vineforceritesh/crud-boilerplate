using System.ComponentModel.DataAnnotations;

namespace UserCrud.Collage.Dto
{
    public class UpdateCollegeDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }
        public long PhoneNumber { get; set; }

        public bool IsActive { get; set; }
    }
}
