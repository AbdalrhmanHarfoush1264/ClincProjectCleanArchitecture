using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.Schedules.Queries.Responses;
using MediatR;

namespace ClincProject.Core.Features.Schedules.Queries.Models
{
    public class GetScheduleByIdQuery : IRequest<CusResponse<GetScheduleByIdResponse>>
    {
        public int Id { get; set; }
        public GetScheduleByIdQuery(int id)
        {
            Id = id;
        }
    }
}
