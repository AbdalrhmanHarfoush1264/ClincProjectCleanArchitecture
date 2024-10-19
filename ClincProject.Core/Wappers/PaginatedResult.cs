namespace ClincProject.Core.Wappers
{
    public class PaginatedResult<T>
    {

        #region Fileds
        public List<T> Data { get; set; }
        public int Currentpage { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        //public object Meta { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => Currentpage > 1;
        public bool HasNextPage => Currentpage < TotalPages;
        public bool Succeeded { get; set; }
        public List<string> Messages { get; set; } = new();
        #endregion

        #region Constructors

        public PaginatedResult(List<T> data)
        {
            this.Data = data;
        }

        public PaginatedResult(bool succeeded, List<T> data = default, List<string> messages = null,
            int totalCount = 0, int page = 1, int pageSize = 10)
        {
            this.Succeeded = succeeded;
            this.Data = data;
            this.Messages = messages;
            this.TotalCount = totalCount;
            this.Currentpage = page;
            this.PageSize = pageSize;
            this.TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        }
        #endregion

        #region Functions

        public static PaginatedResult<T> Success(List<T> Data, int Count, int Page, int PageSize)
        {
            return new(true, Data, null, Count, Page, PageSize);
        }
        #endregion
    }
}
