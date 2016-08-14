using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AccountBook.Models;

namespace AccountBook.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbSet<T> _Objectset;
        private DbSet<T> ObjectSet
        {
            get
            {
                if (_Objectset == null)
                {
                    _Objectset = UnitOfWork.Context.Set<T>();
                }
                return _Objectset;
            }
        }

        public IUnitOfWork UnitOfWork { get; set; }

        public Repository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IQueryable<T> LookupAll()
        {
            return ObjectSet;
        }

        public void Create(T entity)
        {
            ObjectSet.Add(entity);
        }

        public void Commit()
        {
            UnitOfWork.Save();
        }
    }
}