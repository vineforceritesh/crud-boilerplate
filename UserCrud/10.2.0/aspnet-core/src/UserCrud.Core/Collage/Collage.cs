using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCrud.Collage
{
    public  class Collage : FullAuditedEntity<int>
    {

        public string Name { get; set; }
        public string Address { get; set; }
        public long PhoneNumber { get; set; }

        public bool IsActive { get; set; }
        protected Collage()
        {
            // EF Core
        }
        public Collage(
            string name,
            string address,
            long phoneNumber)
        {
            this.Name = name;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            IsActive = true;
        }
    }


}
