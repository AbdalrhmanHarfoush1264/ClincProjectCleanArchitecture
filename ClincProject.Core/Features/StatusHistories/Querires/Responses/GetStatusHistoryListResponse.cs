namespace ClincProject.Core.Features.StatusHistories.Querires.Responses
{
    public class GetStatusHistoryListResponse
    {
        public int Id { get; set; }
        public DateOnly StatusTime { get; set; }
        public string StatusName { get; set; } = null!;
        public string? details { get; set; }
    }
}
