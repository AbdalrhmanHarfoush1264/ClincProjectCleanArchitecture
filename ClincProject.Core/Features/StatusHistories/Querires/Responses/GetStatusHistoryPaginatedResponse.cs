namespace ClincProject.Core.Features.StatusHistories.Querires.Responses
{
    public class GetStatusHistoryPaginatedResponse : GetStatusHistoryListResponse
    {

        public GetStatusHistoryPaginatedResponse(int id, DateOnly statusTime, string statusName, string? Details)
        {
            Id = id;
            StatusTime = statusTime;
            StatusName = statusName;
            details = Details;
        }
    }
}
