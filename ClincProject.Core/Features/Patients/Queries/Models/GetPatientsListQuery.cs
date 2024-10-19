using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.Patients.Queries.Responses;
using MediatR;

namespace ClincProject.Core.Features.Patients.Queries.Models
{
    public class GetPatientsListQuery : IRequest<CusResponse<List<GetPatientsListResponse>>>
    {

    }
}
