using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Program.DTO
{
    public class Employee
    {
        public int IdEmployee { get; set; }
        public string PersonalNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public int IdStatus { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? LeaveDate { get; set; }
    }
}
