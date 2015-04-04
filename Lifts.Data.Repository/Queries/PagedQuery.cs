using System;
using System.Collections.Generic;
using System.Linq;
using Lifts.Data.Repository.Queries.Specifications;
using Lifts.Data.Repository.Repositories;

namespace Lifts.Data.Repository.Queries
{
    /// <summary>
    /// Performs a Paged Query on a repository.
    /// </summary>
    /// <typeparam name="T">Type of object stored in the Repository.</typeparam>
    public class PagedQuery<T> : RepositoryQuery<T> where T : class, IAggregateRoot
    {
        public int PageIndex { get; private set; }

        public bool ReachedLimit
        {
            get { return PageIndex * Specification.PageSize >= Specification.MaxResults; }
        }

        internal PagedQuerySpecification Specification { get; set; }

        public PagedQuery(Func<T, bool> query)
            : this(query, 200, 25)
        {
        }

        public PagedQuery(Func<T, bool> query, int maxResults, int pageSize)
            : this(query, maxResults, pageSize, 0)
        {
        }

        public PagedQuery(Func<T, bool> query, int maxResults, int pageSize, int currentIndex)
            : base(query)
        {
            PageIndex = currentIndex;
            Specification = new PagedQuerySpecification(maxResults, pageSize);
        }

        public override IEnumerable<T> Perform(IRepository<T> repository)
        {
            IEnumerable<T> result = repository.Find(Query)
                .Skip(Specification.PageSize * PageIndex)
                .Take(Specification.PageSize);

            PageIndex++;
            return result;
        }
    }
}
