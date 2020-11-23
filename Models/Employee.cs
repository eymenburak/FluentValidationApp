using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname{ get; set; }
        public string CreditCardNumber { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public IList<Department> Departments { get; set; }

        public Gender Gender { get; set; }
    }
}
