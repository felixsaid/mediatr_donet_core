using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorManagement.Models
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
        }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
