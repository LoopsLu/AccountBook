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
        Expense,
        [Display(Name = "收入")]
        Income,
        收入
    }
    public class AccountBookViewModel
    {
        public int Id { get; set; }

        [Display(Name = "類別")]
        public CategoryEnum? Category { get; set; }

        [Display(Name = "金額")]
        public decimal Value { get; set; }

        [Display(Name = "日期")]
        public DateTime DateTime { get; set; }

        [Display(Name = "備註")]
        public string Comment { get; set; }
    }
}