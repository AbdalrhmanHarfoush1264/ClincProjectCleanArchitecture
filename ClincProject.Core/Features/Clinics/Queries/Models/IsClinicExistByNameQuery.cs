using ClincProject.Core.BasesCore;
using MediatR;

namespace ClincProject.Core.Features.Clinics.Queries.Models
{
    public class IsClinicExistByNameQuery : IRequest<CusResponse<string>>
    {
        public string ClinicName { get; set; } = null!;
    }
}
