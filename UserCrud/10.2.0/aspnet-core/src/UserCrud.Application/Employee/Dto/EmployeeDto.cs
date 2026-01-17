using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCrud.Employee.Dto
{
    public  class EmployeeDto : EntityDto<int>
    {
       
        public string name { get; set; }
        public string email { get; set; }
        public string position { get; set; } 
        public int salary { get; set; }
    }
}
