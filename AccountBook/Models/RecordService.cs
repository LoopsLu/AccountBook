using AccountBook.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountBook.Models
{
    public class RecordService
    {
        private readonly AccountBookRecordModel _db;

        public RecordService()
        {
            _db = new AccountBookRecordModel();
        }

        public IEnumerable<AccountBookViewModel> GetAll()
        {
            var viewModel = _db.AccountBook.Select(x =>
            new AccountBookViewModel
            {
                Category = (CategoryEnum)x.Categoryyy,
                Value = x.Amounttt,
                DateTime = x.Dateee,
                Comment = x.Remarkkk
            });
            return viewModel;
        }
    }
}