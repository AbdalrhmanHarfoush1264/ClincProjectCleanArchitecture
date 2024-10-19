using ClincProject.Core.BasesCore;
using MediatR;

namespace ClincProject.Core.Features.PatientCases.Commands.Models
{
    public class DeletePatientCaseCommand : IRequest<CusResponse<string>>
    {
        public int Id { get; set; }
        public DeletePatientCaseCommand(int id)
        {
            Id = id;
        }
    }
}
