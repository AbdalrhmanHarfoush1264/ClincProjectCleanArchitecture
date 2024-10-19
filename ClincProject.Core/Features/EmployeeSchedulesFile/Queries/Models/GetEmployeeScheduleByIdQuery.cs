using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.EmployeeSchedulesFile.Queries.Responses;
using MediatR;

namespace ClincProject.Core.Features.EmployeeSchedulesFile.Queries.Models
{
    public class GetEmployeeScheduleByIdQuery : IRequest<CusResponse<GetSingleEmployeeScheduleResponse>>
    {
        public int Id { get; set; }
        public GetEmployeeScheduleByIdQuery(int id)
        {
            Id = id;
        }
    }
}
