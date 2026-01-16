using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCrud.Employee.Dto
{
    public class UpdateEmployeeDto
    {
         public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string position { get; set; }
        public int salary { get; set; }
    }
}
