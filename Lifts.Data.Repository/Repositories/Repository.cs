using System;
using System.Collections.Generic;
using System.Linq;
using Lifts.Data.Repository.Queries;
using Lifts.Data.Repository.UnitsOfWork;

namespace Lifts.Data.Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Contructors

        public Repository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");

            _unitOfWork = unitOfWork;
        }

        #endregion Constructors

        #region IRepository

        public int Count
        {
            get { return _unitOfWork.Set<T>().Count(); }
        }

        public virtual bool IsReadOnly
        {
            get { return false; }
        }

        public void Add(T item)
        {
            _unitOfWork.Add(item);
        }

        public virtual void Clear()
        {
            throw new NotImplementedException("Default implementation does not allow the Repository to be cleared.");
        }

        public bool Contains(T item)
        {
            return _unitOfWork.Set<T>().Contains<T>(item);
        }

        public bool Remove(T item)
        {
            return _unitOfWork.Remove(item);
        }

        public IEnumerable<T> Find(Func<T, bool> query)
        {
            return _unitOfWork.Set<T>().Where(query);
        }

        public IEnumerable<T> Find(IRepositoryQuery<T> query)
        {
            if (query == null)
                throw new ArgumentNullException("query");

            return query.Perform(this);
        }

        public IEnumerable<T> All()
        {
            return Find(new AllQuery<T>());
        }

        #endregion IRepository
    }
}
