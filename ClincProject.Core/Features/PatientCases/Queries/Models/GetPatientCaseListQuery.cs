using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.PatientCases.Queries.Responses;
using MediatR;

namespace ClincProject.Core.Features.PatientCases.Queries.Models
{
    public class GetPatientCaseListQuery : IRequest<CusResponse<List<GetPatientCaseListResponse>>>
    {


    }
}
