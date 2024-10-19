using ClincProject.Core.BasesCore;
using MediatR;

namespace ClincProject.Core.Features.Clinics.Commands.Models
{
    public class DeleteClinicCommand : IRequest<CusResponse<string>>
    {
        public int Id { get; set; }

        public DeleteClinicCommand(int id)
        {
            Id = id;
        }
    }
}
