using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string SchoolNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Class{ get; set; }
        public string Schoolname{ get; set; }
        public string IDCardNumber { get; set; }
        public string PhoneNumber { get; set; }
        public Telephone Telephone { get; set; }

        public string GetCsvStudentDefinition()
        {
            return $"{Name},{Surname},{SchoolNumber},{PhoneNumber}";
        }
    }
}
