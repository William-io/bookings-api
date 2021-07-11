using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookings.Validations
{
    public class TitleAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))        
            {
                return ValidationResult.Success;
            }

            var firstText = value.ToString()[0].ToString();
            if (firstText != firstText.ToUpper())
            {
                return new ValidationResult("A Primeira letra do nome deve ser maiúscula");
            }

            return ValidationResult.Success;
        }

    }
}
