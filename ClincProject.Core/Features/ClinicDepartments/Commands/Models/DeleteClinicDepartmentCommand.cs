using ClincProject.Core.BasesCore;
using MediatR;

namespace ClincProject.Core.Features.ClinicDepartments.Commands.Models
{
    public class DeleteClinicDepartmentCommand : IRequest<CusResponse<string>>
    {
        public int Id { get; set; }
        public DeleteClinicDepartmentCommand(int id)
        {
            Id = id;
        }
    }
}
