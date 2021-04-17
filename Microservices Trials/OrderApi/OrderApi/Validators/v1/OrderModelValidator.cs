using FluentValidation;
using OrderApi.Models.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Validators.v1
{
    public class OrderModelValidator:AbstractValidator<OrderModel>
    {
        public OrderModelValidator()
        {
            RuleFor(x => x.CustomerFullName)
                .NotNull()
                .WithMessage("The customer name must be at least 2 characters long");

            RuleFor(x => x.CustomerFullName)
                .MinimumLength(2).WithMessage("The customer name must be atleast 2 characters long");
        }
    }
}
