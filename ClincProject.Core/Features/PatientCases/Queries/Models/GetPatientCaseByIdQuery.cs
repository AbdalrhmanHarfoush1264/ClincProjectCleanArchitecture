using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.PatientCases.Queries.Responses;
using MediatR;

namespace ClincProject.Core.Features.PatientCases.Queries.Models
{
    public class GetPatientCaseByIdQuery : IRequest<CusResponse<GetSinglePatientCaseResponse>>
    {
        public int Id { get; set; }
        public GetPatientCaseByIdQuery(int id)
        {
            Id = id;
        }
    }
}
