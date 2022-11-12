namespace EmploymentApp.Contracts.BusinessObjects
{
    public class PagationFilter
    {
        public int Start { set; get; }
        public int Rows { set; get; }
        public int SortOrder { set; get; }
        public string SortField { set; get; }
        public List<PagationFilterColumn> Columns { set; get; }

    }

    public class PagationFilterColumn
    {
        public string Name { set; get; }
        public string Value { set; get; }
        public string MatchMode { set; get; }
    }
}
