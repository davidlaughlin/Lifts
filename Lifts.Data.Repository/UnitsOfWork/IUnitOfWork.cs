using System;
using System.Linq;

namespace Lifts.Data.Repository.UnitsOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IQueryable<T> Set<T>() where T : class, IAggregateRoot;

        void Add<T>(T item) where T : class, IAggregateRoot;
        bool Remove<T>(T item) where T : class, IAggregateRoot;

        void SaveChanges();
    }
}
