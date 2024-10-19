using ClincProject.Core.Features.Users.Commands.Models;
using ClincProject.Data.Entities.Identities;

namespace ClincProject.Core.Mapping.Users
{
    public partial class UserProfile
    {
        public void EditUserMapping()
        {
            CreateMap<EditUserCommand, User>();
        }
    }
}
