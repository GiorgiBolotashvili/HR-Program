using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Program.Domain.Attribute
{
    public class MinimumAgeAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;
        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime date)
            {
                var age = DateTime.Today.Year - date.Year;
                if (date > DateTime.Today.AddYears(-age))
                {
                    age--;
                }
                if (age < _minimumAge)
                {
                    return new ValidationResult($"You must be at least {_minimumAge} years old to register");
                }
                return ValidationResult.Success;
            }
            return new ValidationResult("Invalid date of birth");

        }
    }
}