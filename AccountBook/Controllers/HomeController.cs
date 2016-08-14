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
                RecordQueryResult = _recordSvc.GetAll().OrderByDescending(x=>x.DateTime)
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
        public ActionResult CreateAccountRecordAndShowResult(IndexViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.AccountRecord.Id = Guid.NewGuid();
                _recordSvc.Add(viewModel.AccountRecord);
                _recordSvc.Save();
                return View(_recordSvc.GetAll().OrderByDescending(x => x.DateTime));
            }

            // 想要在回傳資料為null時跳出錯誤，
            // 但是在Index中用AJAX的OnFailure，無論成功或失敗都會執行alert
            // 在_accountBookList加入alert，卻怎麼也不alert
            // 但是在CreateAccountRecordAndShowResult寫入判斷式後卻可以成功顯示alert...
            return View();
        }
    }
}