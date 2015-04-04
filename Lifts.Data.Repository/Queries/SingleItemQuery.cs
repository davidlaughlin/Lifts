using System;

namespace Lifts.Data.Repository.Queries
{
    public class SingleItemQuery<T> : RestrictedQuery<T> where T : class, IAggregateRoot
    {
        public SingleItemQuery(Func<T, bool> query)
            : base(query, 1)
        {
            Query = query;
        }
    }
}
