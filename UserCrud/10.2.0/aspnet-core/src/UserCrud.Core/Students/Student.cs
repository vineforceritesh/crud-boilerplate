using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCrud.Students
{
    public class Student : FullAuditedEntity<int>
    {
        
        public string StudentCode { get; set; }   
        public string Name { get; set; }
        public string Email { get; set; }

        
        public int Age { get; set; }
        public string College { get; set; }

     
        public bool IsActive { get; set; }

        protected Student()
        {
            // EF Core

            
            
        }

        public Student(
            string name,
            string email,
            int age,
            string college)
        {
            Name = name;
            Email = email;
            Age = age;
            College = college;
            IsActive = true;
        }
    }
}
