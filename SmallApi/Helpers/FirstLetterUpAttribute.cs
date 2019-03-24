using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmallApi.Helpers
{
    public class FirstLetterUpAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var firstLeter = value.ToString()[0].ToString();

            if(firstLeter != firstLeter.ToUpper())
            {
                return new ValidationResult("The first Letter should be upper case.");
            }

            return ValidationResult.Success;
        }
    }
}
