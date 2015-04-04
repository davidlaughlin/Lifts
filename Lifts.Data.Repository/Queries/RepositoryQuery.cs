using System;
using System.Collections.Generic;
using Lifts.Data.Repository.Repositories;

namespace Lifts.Data.Repository.Queries
{
    public abstract class RepositoryQuery<T> : IRepositoryQuery<T> where T : class, IAggregateRoot
    {
        #region Properties

        protected Func<T, bool> Query;

        #endregion Properites

        #region Constructors

        protected RepositoryQuery(Func<T, bool> query)
        {
            Query = query;
        }

        #endregion Constructors

        #region Abstract Methods

        public abstract IEnumerable<T> Perform(IRepository<T> repository);

        #endregion Abstract Methods
    }
}
