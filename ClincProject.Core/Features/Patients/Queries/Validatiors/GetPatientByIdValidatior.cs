using ClincProject.Core.Features.Patients.Queries.Models;
using FluentValidation;

namespace ClincProject.Core.Features.Patients.Queries.Validatiors
{
    public class GetPatientByIdValidatior : AbstractValidator<GetPatientByIdQuery>
    {

        #region Fileds

        #endregion

        #region Constructor(s)
        public GetPatientByIdValidatior()
        {
            ApplyValidationsRules();
        }

        #endregion

        #region Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Can't be empty.")
                .NotNull().WithMessage("Can't be blank.");
        }

        public void ApplyCustomValidationsRules()
        {

        }
        #endregion





    }
}
