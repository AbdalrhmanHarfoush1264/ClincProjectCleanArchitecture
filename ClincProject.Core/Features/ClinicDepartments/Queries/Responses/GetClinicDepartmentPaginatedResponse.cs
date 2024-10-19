namespace ClincProject.Core.Features.ClinicDepartments.Queries.Responses
{
    public class GetClinicDepartmentPaginatedResponse : GetClinicDepartmentResponse
    {

        public GetClinicDepartmentPaginatedResponse(int id, string departmentName, string? description, string clinicName)
        {
            Id = id;
            DepartmentName = departmentName;
            Description = description;
            ClinicName = clinicName;
        }
    }
}
