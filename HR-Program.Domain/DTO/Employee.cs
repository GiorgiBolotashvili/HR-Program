using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Program.Domain.DTO
{
    public class Employee
    {
        public int IdEmployee { get; set; }

        [Required(ErrorMessage = "Personal number is required")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Personal number must be exactly 11 characters")]
        public string PersonalNumber { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateOfBirth { get; set; }
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public int IdStatus { get; set; }
        public string Status { get; set; }
        public DateTime? LeaveDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}
