using System.Collections.Generic;
using Lifts.Data.Repository.Repositories;

namespace Lifts.Data.Repository.Queries
{
    public interface IRepositoryQuery<T> where T : class, IAggregateRoot
    {
        IEnumerable<T> Perform(IRepository<T> repository);
    }
}
