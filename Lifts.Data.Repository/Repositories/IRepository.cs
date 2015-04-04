using System;
using System.Collections.Generic;
using Lifts.Data.Repository.Queries;

namespace Lifts.Data.Repository.Repositories
{
    public interface IRepository<T> where T : class, IAggregateRoot
    {
        int Count { get; }
        bool IsReadOnly { get; }

        void Add(T item);
        void Clear();
        bool Contains(T item);
        bool Remove(T item);

        IEnumerable<T> Find(Func<T, bool> query);
        IEnumerable<T> Find(IRepositoryQuery<T> query);

        IEnumerable<T> All();
    }
}
