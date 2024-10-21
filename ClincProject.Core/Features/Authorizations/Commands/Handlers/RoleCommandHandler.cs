using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.Authorizations.Commands.Models;
using ClincProject.Service.Abstracts;
using MediatR;

namespace ClincProject.Core.Features.Authorizations.Commands.Handlers
{
    public class RoleCommandHandler : CusResponseHandler,
        IRequestHandler<AddRoleCommand, CusResponse<string>>,
        IRequestHandler<EditRoleCommand, CusResponse<string>>,
        IRequestHandler<DeleteRoleCommand, CusResponse<string>>,
        IRequestHandler<EditUserRolesCommand, CusResponse<string>>
    {
        #region Fileds
        private readonly IAuthorizationService _authorizationService;
        #endregion

        #region Constructors
        public RoleCommandHandler(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }
        #endregion

        #region Functions
        public async Task<CusResponse<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var isExist = await _authorizationService.IsRoleNameExist(request.roleName);
                if (isExist)
                    return BadRequest<string>("this role name is already exist.");

                var IsAdded = await _authorizationService.AddRoleAsync(request.roleName);

                if (!IsAdded) return BadRequest<string>("Added operation failed.");

                return Success("Added Operation Successfully.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }

        public async Task<CusResponse<string>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var isExist = await _authorizationService.IsRoleNameExist(request.roleName);
                if (isExist)
                    return BadRequest<string>("this role name is already exist.");

                var IsEdited = await _authorizationService.EditRoleById(request.Id, request.roleName);

                if (!IsEdited) return BadRequest<string>("Edited operation failed.");

                return Success("Edited Operation Successfully.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }

        public async Task<CusResponse<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var role = await _authorizationService.GetRoleByID(request.Id);
                if (role == null)
                    return NotFound<string>("role with this id not found!");

                var IsDeleted = await _authorizationService.DeleteRoleById(role);
                if (!IsDeleted)
                    return BadRequest<string>("Deleted Operation Failed.");

                return Success("Deleted Operation Successfully.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }

        public async Task<CusResponse<string>> Handle(EditUserRolesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _authorizationService.UpdateUserRoles(request);
                switch (result)
                {
                    case "UserNotFound":
                        return NotFound<string>("user with this id not found");
                    case "FailedDeleted":
                        return BadRequest<string>("Deleted Operation Failed.");
                    case "FailedAdded":
                        return Success("Added Operation Failed.");
                }

                return Success("Updated Operation Successfully.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }
        #endregion

    }
}
