using ClincProject.Core.BasesCore;
using ClincProject.Data.Helpers;
using MediatR;

namespace ClincProject.Core.Features.Authorizations.Commands.Models
{
    public class EditUserRolesCommand : EditUserRolesRequest,
        IRequest<CusResponse<string>>
    {

    }
}
