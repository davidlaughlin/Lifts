using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;

namespace Lifts.Data.Repository.UnitsOfWork
{
    public class EntityFrameworkUnitOfWork : IUnitOfWork, IDisposable
    {
        #region Members

        private readonly DbContext _context;

        #endregion Members

        #region Constructors

        public EntityFrameworkUnitOfWork(string connectionString)
        {
            _context = new DbContext(connectionString);
        }

        public EntityFrameworkUnitOfWork(DbContext context)
        {
            _context = context;
        }

        public EntityFrameworkUnitOfWork(IDbContextFactory<DbContext> factory)
        {
            _context = factory.Create();
        }

        #endregion Constructors

        #region Methods

        public IQueryable<T> Set<T>() where T : class, IAggregateRoot
        {
            return _context.Set<T>();
        }

        public void Add<T>(T item) where T : class, IAggregateRoot
        {
            _context.Set<T>().Add(item);
        }

        public bool Remove<T>(T item) where T : class, IAggregateRoot
        {
            return _context.Set<T>().Remove(item) != null;
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Debug.WriteLine("Disposing EntityFrameworkUnitOfWork");
            SaveChanges();
            _context.Dispose();
        }

        #endregion Methods
    }
}
