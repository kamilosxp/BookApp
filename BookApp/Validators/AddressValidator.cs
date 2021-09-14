using System;
using BookApp.Models;
using FluentValidation;

namespace BookApp.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(address => address.Name).NotNull()
                .MinimumLength(3);
            RuleFor(address => address.Surname).NotNull()
                .MinimumLength(3);
            RuleFor(address => address.Street).NotNull()
                .MinimumLength(3);
            RuleFor(address => address.HouseAndFlatNumber).NotNull()
                .MinimumLength(3);
            RuleFor(address => address.ZIPCode).NotNull()
                .MinimumLength(3);
            RuleFor(address => address.City).NotNull()
                .MinimumLength(3);
        }
    }
}
