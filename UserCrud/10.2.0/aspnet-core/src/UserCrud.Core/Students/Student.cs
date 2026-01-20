using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;
using UserCrud.Collage;

namespace UserCrud.Students
{
    public class Student : FullAuditedEntity<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public int CollegeId { get; set; }

        [ForeignKey(nameof(CollegeId))]
        public Collage.Collage College { get; set; }

        public bool IsActive { get; set; }

        protected Student() { }

        public Student(string name, string email, int age, int collegeId)
        {
            Name = name;
            Email = email;
            Age = age;
            CollegeId = collegeId;
            IsActive = true;
        }
    }
}
