using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.Schedules.Queries.Responses;
using MediatR;

namespace ClincProject.Core.Features.Schedules.Queries.Models
{
    public class GetScheduleListQuery : IRequest<CusResponse<List<GetScheduleListResponse>>>
    {

    }
}
