using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.ClinicDepartments.Queries.Responses;
using MediatR;

namespace ClincProject.Core.Features.ClinicDepartments.Queries.Models
{
    public class GetClinicDepartmentListQuery : IRequest<CusResponse<List<GetClinicDepartmentResponse>>>
    {

    }
}
