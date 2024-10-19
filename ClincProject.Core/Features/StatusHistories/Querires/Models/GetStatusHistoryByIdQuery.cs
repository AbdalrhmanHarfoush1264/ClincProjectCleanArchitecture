using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.StatusHistories.Querires.Responses;
using MediatR;

namespace ClincProject.Core.Features.StatusHistories.Querires.Models
{
    public class GetStatusHistoryByIdQuery : IRequest<CusResponse<GetSingleStatusHistoryResponse>>
    {
        public int Id { get; set; }
        public GetStatusHistoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
