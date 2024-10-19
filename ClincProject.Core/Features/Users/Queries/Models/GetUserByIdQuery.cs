using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.Users.Queries.Responses;
using MediatR;

namespace ClincProject.Core.Features.Users.Queries.Models
{
    public class GetUserByIdQuery : IRequest<CusResponse<GetUserByIdResponse>>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
