namespace ClincProject.Core.Features.PatientCases.Queries.Responses
{
    public class GetPatientCasePaginatedResponse : GetPatientCaseListResponse
    {

        public GetPatientCasePaginatedResponse(int id, DateOnly startTime, DateOnly? endTime, bool inProgress,
            decimal totalCost, decimal amountPaid, string patientName)
        {
            Id = id;
            StartTime = startTime;
            EndTime = endTime;
            InProgress = inProgress;
            TotalCost = totalCost;
            AmountPaid = amountPaid;
            PatientName = patientName;
        }
    }
}
