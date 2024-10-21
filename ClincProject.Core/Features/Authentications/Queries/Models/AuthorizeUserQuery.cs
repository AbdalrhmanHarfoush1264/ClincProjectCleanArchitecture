using ClincProject.Core.BasesCore;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ClincProject.Core.Features.Authentications.Queries.Models
{
    public class AuthorizeUserQuery : IRequest<CusResponse<string>>
    {
        [Required(ErrorMessage = "AccessToken can't be blank.")]
        public string Accesstoken { get; set; } = null!;
    }
}
