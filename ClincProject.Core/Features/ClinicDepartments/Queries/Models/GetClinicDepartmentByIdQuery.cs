using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.ClinicDepartments.Queries.Responses;
using MediatR;

namespace ClincProject.Core.Features.ClinicDepartments.Queries.Models
{
    public class GetClinicDepartmentByIdQuery : IRequest<CusResponse<GetClinicDepartmentResponse>>
    {

        public int Id { get; set; }

        public GetClinicDepartmentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
