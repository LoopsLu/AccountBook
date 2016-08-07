using AccountBook.Models.ViewModels;
using AccountBook.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountBook.Models
{
    public class RecordService : Repository<AccountBook>
    {

        private readonly IRepository<AccountBook> _accountBookRep;

        public RecordService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _accountBookRep = new Repository<AccountBook>(unitOfWork);
        }

        public IEnumerable<AccountBookViewModel> GetAll()
        {
            return _accountBookRep.LookupAll().Select(x =>
            new AccountBookViewModel
            {
                Category = (CategoryEnum)x.Categoryyy,
                Value = x.Amounttt,
                DateTime = x.Dateee,
                Comment = x.Remarkkk
            });
        }

    }
}