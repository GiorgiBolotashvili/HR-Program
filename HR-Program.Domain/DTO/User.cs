using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HR_Program.Domain.Attribute;

namespace HR_Program.Domain.DTO
{
    public class User
    {
        public int IdUser { get; set; }

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
        [MinimumAge(18, ErrorMessage = "You must be at least 18 years old to register")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "Password must contain at least one capital letter and one digit")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        public string PasswordConfirm { get; set; }
    }
}
