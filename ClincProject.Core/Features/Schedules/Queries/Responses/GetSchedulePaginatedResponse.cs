namespace ClincProject.Core.Features.Schedules.Queries.Responses
{
    public class GetSchedulePaginatedResponse : GetScheduleListResponse
    {

        public GetSchedulePaginatedResponse(int id, DateOnly date, TimeOnly timeStart, TimeOnly timeEnd,
            string doctorName, string departmentName)
        {
            Id = id;
            Date = date;
            TimeStart = timeStart;
            TimeEnd = timeEnd;
            DoctorName = doctorName;
            DepartmentName = departmentName;
        }
    }
}
