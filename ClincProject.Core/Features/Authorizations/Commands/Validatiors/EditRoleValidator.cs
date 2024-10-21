using ClincProject.Core.Features.Authorizations.Commands.Models;
using FluentValidation;

namespace ClincProject.Core.Features.Authorizations.Commands.Validatiors
{
    public class EditRoleValidator : AbstractValidator<EditRoleCommand>
    {
        #region Constructors
        public EditRoleValidator()
        {
            ApplyValidationsRules();
        }
        #endregion

        #region Handle Fnctions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("Can't be balnk.");

            RuleFor(x => x.roleName)
                .NotNull().WithMessage("Can't be balnk.");
        }
        #endregion
    }
}
