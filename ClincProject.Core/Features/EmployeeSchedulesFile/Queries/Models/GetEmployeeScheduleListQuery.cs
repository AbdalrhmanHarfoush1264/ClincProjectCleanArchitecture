using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.EmployeeSchedulesFile.Queries.Responses;
using MediatR;

namespace ClincProject.Core.Features.EmployeeSchedulesFile.Queries.Models
{
    public class GetEmployeeScheduleListQuery : IRequest<CusResponse<List<GetEmployeeScheduleListResponse>>>
    {

    }
}
