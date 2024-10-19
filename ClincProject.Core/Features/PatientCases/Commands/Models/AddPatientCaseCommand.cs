using ClincProject.Core.BasesCore;
using MediatR;

namespace ClincProject.Core.Features.PatientCases.Commands.Models
{
    public class AddPatientCaseCommand : IRequest<CusResponse<string>>
    {
        public int PatientId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool InProgress { get; set; }
        public decimal TotalCost { get; set; }
        public decimal AmountPaid { get; set; }
    }
}
