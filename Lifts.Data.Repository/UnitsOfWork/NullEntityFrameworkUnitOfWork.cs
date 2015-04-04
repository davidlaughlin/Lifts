using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Lifts.Data.Repository.UnitsOfWork
{
    public class NullEntityFrameworkUnitOfWork : EntityFrameworkUnitOfWork
    {
        #region Constructors

        public NullEntityFrameworkUnitOfWork(string connectionString) : base(connectionString)
        {
        }

        public NullEntityFrameworkUnitOfWork(DbContext context) : base(context)
        {
        }

        public NullEntityFrameworkUnitOfWork(IDbContextFactory<DbContext> factory) : base(factory)
        {
        }

        public new void Dispose()
        {
        }

        #endregion Constructors

        public override void SaveChanges()
        {
            // Do nothing
        }
    }
}