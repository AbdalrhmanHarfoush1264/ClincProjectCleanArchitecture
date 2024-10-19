using ClincProject.Core.BasesCore;
using MediatR;

namespace ClincProject.Core.Features.Patients.Commands.Models
{
    public class DeletePatientCommand : IRequest<CusResponse<string>>
    {
        public int Id { get; set; }
        public DeletePatientCommand(int id)
        {
            Id = id;
        }
    }
}
