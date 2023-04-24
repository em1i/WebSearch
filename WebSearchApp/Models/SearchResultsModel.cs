namespace WebSearch.Models
{
    public class SearchResultsModel
    {
        public string SearchText { get; set; }
        public List<Details> Results { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
    }
}