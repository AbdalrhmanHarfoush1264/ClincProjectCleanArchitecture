namespace ClincProject.Core.Features.ClinicDepartments.Queries.Responses
{
    public class GetClinicDepartmentResponse
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string? Description { get; set; }
        public string ClinicName { get; set; }
    }
}
