using ContactManagement.Domain.Entities;
using ContactManagement.Domain.Entities.Enum;
using FluentValidation;
using FluentValidation.Validators;

namespace ContactManagement.Domain.Validator
{
    public class ContactUserValidator : AbstractValidator<ContactUser>
    {
        public ContactUserValidator(Action action)
        {
            ValidarNome();
            ValidarEmail();

            if (action == Action.Update)
            {
                ValidarId();
            }
        }

        protected void ValidarNome()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MinimumLength(5);
        }

        protected void ValidarId()
        {
	        RuleFor(c => c.Id).GreaterThan(0).WithMessage("The value Id is invalid.");
        }

        protected void ValidarEmail()
        {
	        RuleFor(c => c.Email).EmailAddress(EmailValidationMode.AspNetCoreCompatible);
        }
    }
}