using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBook.Repositories
{
    interface IRepository<T> where T : class
    {
        /// <summary>
        /// unit of work
        /// </summary>
        IUnitOfWork UnitOfWork { get; set; }

        /// <summary>
        /// Lookups all.
        /// </summary>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        IQueryable<T> LookupAll();
    }
}
