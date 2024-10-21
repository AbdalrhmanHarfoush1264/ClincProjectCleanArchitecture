using ClincProject.Core.Features.Authorizations.Commands.Models;
using FluentValidation;

namespace ClincProject.Core.Features.Authorizations.Commands.Validatiors
{
    public class AddRoleValidator : AbstractValidator<AddRoleCommand>
    {

        #region Constructors
        public AddRoleValidator()
        {
            ApplyValidationsRules();
        }
        #endregion

        #region Handle Fnctions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.roleName)
                .NotNull().WithMessage("Can't be balnk.");
        }
        #endregion
    }
}
