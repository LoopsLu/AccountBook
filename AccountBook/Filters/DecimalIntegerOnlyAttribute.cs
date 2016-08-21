using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccountBook.Filters
{
    public class DecimalIntegerOnlyAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName + ": 格式錯誤"));
            }

            if (value is decimal)
            {
                if (value.ToString().Contains("."))
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName + ": 必須為整數"));
                else
                    return ValidationResult.Success;
            }

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName + ": 格式錯誤"));

        }
    }
}