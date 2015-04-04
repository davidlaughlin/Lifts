namespace Lifts.Data.Repository.Queries.Specifications
{
    internal class PagedQuerySpecification : QuerySpecification
    {
        internal int PageSize { get; set; }

        internal PagedQuerySpecification()
            : this(200)
        {
        }

        internal PagedQuerySpecification(int maxResults)
            : this(maxResults, 25)
        {
        }

        internal PagedQuerySpecification(int maxResults, int pageSize)
            : base(maxResults)
        {
            PageSize = pageSize;
        }
    }
}
