using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBook.Repositories
{
    interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; set; }
    }
}
