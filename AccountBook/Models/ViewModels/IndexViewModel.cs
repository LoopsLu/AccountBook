using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountBook.Models.ViewModels
{
    public class IndexViewModel
    {
        public AccountBookRecordViewModel AccountRecord { get; set; }
        public IEnumerable<AccountBookRecordViewModel> RecordQueryResult { get; set; }
    }
}