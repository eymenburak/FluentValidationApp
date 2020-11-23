using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace FluentValidationApp.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string DepartmentName { get; set; }
    
        public int CountEmployee { get; set; }

        public virtual Employee Employee { get; set; } 

        
    }
}
