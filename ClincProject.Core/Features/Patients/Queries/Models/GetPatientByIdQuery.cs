using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.Patients.Queries.Responses;
using MediatR;

namespace ClincProject.Core.Features.Patients.Queries.Models
{
    public class GetPatientByIdQuery : IRequest<CusResponse<GetPatientByIdResponse>>
    {
        public int Id { get; set; }

        public GetPatientByIdQuery(int id)
        {
            Id = id;
        }
    }
}
