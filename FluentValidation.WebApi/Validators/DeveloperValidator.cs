using FluentValidation.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidation.WebApi.Validators
{
    public class DeveloperValidator : AbstractValidator<Developer>
    {
        public DeveloperValidator()
        {
            RuleFor(p => p.FirstName)
                // Deprecate. Suggested using Rule level or Class level
                //.Cascade(CascadeMode.StopOnFirstFailure)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .Length(5, 100);

            RuleFor(p => p.LastName)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.Email)
                .EmailAddress()
                .NotNull();

            RuleFor(p => p.Experience)
                .GreaterThanOrEqualTo(0);
        }
    }
}
