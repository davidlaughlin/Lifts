namespace Lifts.Data.Repository.Queries.Specifications
{
    internal class QuerySpecification
    {
        public int MaxResults { get; set; }
        public bool ReachedMaxResults { get; set; }

        public QuerySpecification()
            : this(200)
        {
        }

        public QuerySpecification(int maxResults)
        {
            MaxResults = maxResults;
            ReachedMaxResults = false;
        }
    }
}
