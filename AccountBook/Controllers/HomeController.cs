using AccountBook.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountBook.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<AccountBookViewModel> viewModel = new List<AccountBookViewModel>()
            {
                new AccountBookViewModel() { Id = 1, Category = CategoryEnum.Expense, DateTime = new DateTime(2016, 1, 1), Value = 300 },
                new AccountBookViewModel() { Id = 2, Category = CategoryEnum.Expense, DateTime = new DateTime(2016, 1, 2), Value = 1600 },
                new AccountBookViewModel() { Id = 3, Category = CategoryEnum.Expense, DateTime = new DateTime(2016, 1, 3), Value = 800 }
            };
            ViewData["AccountBookQuery"] = viewModel;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}