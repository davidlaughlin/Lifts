using System;
using System.Collections.Generic;
using System.Linq;
using Lifts.Data.Repository.Queries.Specifications;
using Lifts.Data.Repository.Repositories;

namespace Lifts.Data.Repository.Queries
{
    public class RestrictedQuery<T> : RepositoryQuery<T> where T : class,  IAggregateRoot
    {
        internal QuerySpecification Specification { get; set; }

        public RestrictedQuery(Func<T, bool> query)
            : this(query, 200)
        {
        }

        public RestrictedQuery(Func<T, bool> query, int maxResults)
            : base(query)
        {
            Specification = new QuerySpecification(maxResults);
        }

        public override IEnumerable<T> Perform(IRepository<T> repository)
        {
            IEnumerable<T> result = repository.Find(Query);
            IEnumerable<T> filteredResults = result.Take(Specification.MaxResults);
            return filteredResults;
        }
    }
}
