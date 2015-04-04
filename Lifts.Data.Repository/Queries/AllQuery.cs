using System.Collections.Generic;
using Lifts.Data.Repository.Repositories;

namespace Lifts.Data.Repository.Queries
{
    public class AllQuery<T> : RepositoryQuery<T> where T : class, IAggregateRoot
    {
        public AllQuery() : base(item => true)
        {
        }

        public override IEnumerable<T> Perform(IRepository<T> repository)
        {
            return repository.Find(Query);
        }
    }
}
