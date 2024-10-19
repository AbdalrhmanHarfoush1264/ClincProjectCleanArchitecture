namespace ClincProject.Core.Features.Doctors.Queries.Response
{
    public class GetDoctorsPaginatedResponse : GetDoctorsListResponse
    {
        public GetDoctorsPaginatedResponse(int id, string firstName, string lastName,
            string email, string phone, bool isActive)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            IsActive = isActive;
        }
    }
}
