using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCrud.Employee.Dto
{
    public  class CreateEmployeeDto
    {

        [Required]
        public string name { get; set; }
        [EmailAddress]
        public string email { get; set; }
        public string position { get; set; }
        public int salary { get; set; }

    }
}
