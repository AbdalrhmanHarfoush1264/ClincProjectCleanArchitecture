namespace ClincProject.Core.Features.EmployeeSchedulesFile.Queries.Responses
{
    public class GetEmployeeSchedulePaginatedResponse : GetEmployeeScheduleListResponse
    {

        public GetEmployeeSchedulePaginatedResponse(int id, TimeOnly timeFrom, TimeOnly timeTo, bool isActive,
            string DoctorName, string DepartmentName)
        {
            Id = id;
            TimeFrom = timeFrom;
            TimeTo = timeTo;
            IsActive = isActive;
            doctorName = DoctorName;
            departmentName = DepartmentName;
        }
    }
}
