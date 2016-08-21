using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountBook.Models.ViewModels
{
    public enum CategoryEnum
    {
        [Display(Name = "支出")]
        Expense = 0,
        [Display(Name = "收入")]
        Income = 1
    }

    [Bind(Include = "Id,Category,Value,DateTime,Comment")]
    public class AccountBookRecordViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "類別")]
        public CategoryEnum? Category { get; set; }

        [Required]
        [Display(Name = "金額")]
        public decimal Value { get; set; }

        [Required]
        [Display(Name = "日期")]
        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "備註")]
        public string Comment { get; set; }
    }
}