using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccountBook.Filters
{
    public class DecimalMustBiggerThanZeroAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName + ": 格式錯誤"));
            }

            if (value is decimal)
            {
                decimal valueDecimal = (decimal)value;
                if (valueDecimal > 0)
                    return ValidationResult.Success;
                else
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName + ": 輸入數值必須大於0"));
            }

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName + ": 格式錯誤"));

        }
    }
}