using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCrud.Employee
{
    public  class Employee : FullAuditedEntity<int>
    {

        public int Id { get; set; }
        public string name { get; set; }

        public string email { get; set; }
        public string position { get; set; }
        public int salary { get; set; }

        public bool IsActive { get; set; }
        protected Employee()
        {
            // EF Core
        }

        public Employee(
            string name,
            string email,
            string position,
            int salary)
        {
            this.name = name;
            this.email = email;
            this.position = position;
            this.salary = salary;
            IsActive = true;
        }

    }
}
