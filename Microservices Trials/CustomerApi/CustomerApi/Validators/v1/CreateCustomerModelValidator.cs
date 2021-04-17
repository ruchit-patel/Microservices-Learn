using CustomerApi.Models.v1;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi.Validators.v1
{
    public class CreateCustomerModelValidator: AbstractValidator<CreateCustomerModel>
    {
        public CreateCustomerModelValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .WithMessage("The first name must beat least 2 characters long");

            RuleFor(x => x.FirstName)
                .MinimumLength(2).WithMessage("The first name must be atleast 2 characters long");

            RuleFor(x => x.LastName)
                .NotNull()
                .WithMessage("The last name must beat least 2 characters long");

            RuleFor(x => x.LastName)
                .MinimumLength(2).WithMessage("The last name must be atleast 2 characters long");

            RuleFor(x => x.Birthday)
                .InclusiveBetween(DateTime.Now.AddYears(-150).Date, DateTime.Now)
                .WithMessage("The birthday can not be longer ago than 150 years and can not be in future");

            RuleFor(x => x.Age)
                .InclusiveBetween(0, 150)
                .WithMessage("The minimum age is 0 and maximum age is 150 years");
        }
    }
}
