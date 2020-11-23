using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationApp.DTOs
{
    public class StudentDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SchoolNo { get; set; }
        public int Class { get; set; }
        public string TelephoneBrand { get; set; }
        public string TelephoneNumber { get; set; }
        public string CsvStudentDefinition { get; set; }
    }
}
