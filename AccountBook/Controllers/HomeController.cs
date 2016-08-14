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
            var indexViewModel = new IndexViewModel()
            {
                RecordQueryResult = _recordSvc.GetAll()
            };
            return View(indexViewModel);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(IndexViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.AccountRecord.Id = Guid.NewGuid();
                _recordSvc.Add(viewModel.AccountRecord);
                _recordSvc.Save();
                return RedirectToAction("Index");
            }
            var result = new IndexViewModel()
            {
                AccountRecord = new AccountBookRecordViewModel()
                {
                    Id = viewModel.AccountRecord.Id,
                    Category = viewModel.AccountRecord.Category,
                    Value = viewModel.AccountRecord.Value,
                    Comment = viewModel.AccountRecord.Comment,
                    DateTime = viewModel.AccountRecord.DateTime
                },
                RecordQueryResult = _recordSvc.GetAll()
            };
            return View(result);
        }
    }
}