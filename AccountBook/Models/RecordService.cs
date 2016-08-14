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

        public IEnumerable<AccountBookRecordViewModel> GetAll()
        {
            return _accountBookRep.LookupAll().Select(x =>
            new AccountBookRecordViewModel
            {
                // 這邊應該要做防禦設計，以防Categoryyy沒有在Enum的結果裡面
                Category = (CategoryEnum)x.Categoryyy,
                Value = x.Amounttt,
                DateTime = x.Dateee,
                Comment = x.Remarkkk
            });
        }

        public void Add(AccountBookRecordViewModel record)
        {
            var result = new AccountBook()
            {
                Id = record.Id,
                Categoryyy = (int)record.Category,
                // 這裡的轉換要寫一個Helper來處理轉換失敗的問題，
                // 否則decimal超出int範圍就爆了。
                // 轉換失敗要回傳什麼？還是說進service前就要先驗證？
                Amounttt = (int)record.Value,
                Dateee = record.DateTime,
                Remarkkk = record.Comment
            };
            Add(result);
        }

        public void Add(AccountBook record)
        {
            _accountBookRep.Create(record);
        }

        public void Save()
        {
            _accountBookRep.Commit();
        }

    }
}