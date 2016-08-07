using AccountBook.Models;
using AccountBook.Models.ViewModels;
using AccountBook.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly RecordService _recordSvc;

        public HomeController()
        {
            var unitOfWork = new EFUnitOfWork();
            _recordSvc = new RecordService(unitOfWork);
        }

        public ActionResult Index()
        {
            return View(_recordSvc.GetAll());
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