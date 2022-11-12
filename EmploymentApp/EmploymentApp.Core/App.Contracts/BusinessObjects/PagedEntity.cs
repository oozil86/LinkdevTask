namespace EmploymentApp.Contracts.BusinessObjects
{
    public sealed class PagedEntity<TEntity> where TEntity : class
    {
        /// <summary>
        /// Total items count in the data-set.
        /// </summary>
        public int TotalCount { get; }

        /// <summary>
        /// Collection of items.
        /// </summary>
        public IReadOnlyList<TEntity> Items { get; }

        public PagedEntity(IReadOnlyList<TEntity> items, int totalCount)
            : this(items as IEnumerable<TEntity>, totalCount)
        {
        }

        public PagedEntity(IEnumerable<TEntity> items, int totalCount)
        {
            if (totalCount < 0)
                throw new ArgumentOutOfRangeException(nameof(totalCount)
                    , "Total count can't be less than zero");

            Items = items == null
                ? new List<TEntity>().AsReadOnly()
                : items.ToList().AsReadOnly();
            TotalCount = totalCount;
        }
    }

}
