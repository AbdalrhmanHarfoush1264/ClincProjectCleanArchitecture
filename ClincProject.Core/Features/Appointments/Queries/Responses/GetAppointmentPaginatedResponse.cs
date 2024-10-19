namespace ClincProject.Core.Features.Appointments.Queries.Responses
{
    public class GetAppointmentPaginatedResponse : GetAppointmentListResponse
    {

        public GetAppointmentPaginatedResponse(int id, DateOnly timeCreated, TimeOnly startTime,
            TimeOnly? endTime, string patientName, string doctorName, decimal totalCost, decimal amountPaid, string status)
        {
            Id = id;
            TimeCreated = timeCreated;
            StartTime = startTime;
            EndTime = endTime;
            Patient = patientName;
            Doctor = doctorName;
            TotalCost = totalCost;
            AmountPaid = amountPaid;
            Status = status;
        }
    }
}
