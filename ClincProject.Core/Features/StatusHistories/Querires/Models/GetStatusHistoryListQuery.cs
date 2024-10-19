using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.StatusHistories.Querires.Responses;
using MediatR;

namespace ClincProject.Core.Features.StatusHistories.Querires.Models
{
    public class GetStatusHistoryListQuery : IRequest<CusResponse<List<GetStatusHistoryListResponse>>>
    {

    }
}
