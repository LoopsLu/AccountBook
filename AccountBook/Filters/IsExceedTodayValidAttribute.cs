using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccountBook.Filters
{
    public class IsExceedTodayValidAttribute : ValidationAttribute
    {
        public bool IsExceedTodayValid { get; set; }
        private DateTime _todayLimit { get { return DateTime.Today.AddDays(1).AddMilliseconds(-1); } }

        /// <summary>
        /// 是否允許日期超過今天
        /// </summary>
        /// <param name="">false表示日期超過今天就驗證失敗</param>
        public IsExceedTodayValidAttribute(bool isExceedTodayValid)
        {
            IsExceedTodayValid = isExceedTodayValid;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //自訂驗證寫完了，按下送出鈕卻只會跳出alert視窗，
            // 而不會顯示這裡設定的錯誤訊息
            if (value == null)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName + ": 日期格式錯誤"));
            }

            if (value is DateTime)
            {
                if (IsExceedTodayValid == true)
                    return ValidationResult.Success;

                if ((DateTime)value > _todayLimit)
                {
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName + ": 日期不可超過今天"));
                }
                else
                    return ValidationResult.Success;
            }

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName + ": 日期格式錯誤"));
        }
    }
}