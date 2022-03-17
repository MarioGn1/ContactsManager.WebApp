using FluentValidation;
using System;
using static ContactsManager.Constants.Domain.Contact;

namespace ContactsManager.Application.Commands.AddContact
{
    public class AddContactCommandValidator : AbstractValidator<AddContactCommand>
    {
        public AddContactCommandValidator()
        {
            RuleFor(p => p.FirstName)
                .NotNull()
                .NotEmpty().WithMessage("First Name must be specifed")
                .MinimumLength(3).WithMessage("First Name must be at least 3 characters long")
                .MaximumLength(30).WithMessage("First Name exceeds the authorized size 30");

            RuleFor(p => p.LastName)
                .NotNull()
                .NotEmpty().WithMessage("Last Name must be specifed")
                .MinimumLength(3).WithMessage("Last Name must be at least 3 characters long")
                .MaximumLength(30).WithMessage("Last Name exceeds the authorized size 30");

            RuleFor(p => p.PhoneNumber)
                .MaximumLength(15).WithMessage("Phone Number exceeds the authorized size 15")
                .Matches(PHONE_NUMBER_PATERN).WithMessage("Phone Number format is wrong");

            RuleFor(p => p.Iban)
                .MaximumLength(30).WithMessage("IBAN exceeds the authorized size 30")
                .Matches(IBAN_PATERN).WithMessage("IBAN format is wrong");

            RuleFor(p => p.DateOfBirth)
                .GreaterThan(DateTime.Now.AddYears(-120))
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Invalid date.");

            RuleFor(p => p.Street)
                .NotNull()
                .NotEmpty().WithMessage("Street must be specifed")
                .MaximumLength(50).WithMessage("Street exceeds the authorized size 50");

            RuleFor(p => p.City)
                .NotNull()
                .NotEmpty().WithMessage("City must be specifed")
                .MaximumLength(50).WithMessage("City exceeds the authorized size 50");

            RuleFor(p => p.Country)
                .NotNull()
                .NotEmpty().WithMessage("Country must be specifed")
                .MaximumLength(50).WithMessage("Country exceeds the authorized size 50");

            RuleFor(p => p.ZipCode)
                .NotNull()
                .NotEmpty().WithMessage("ZipCode must be specifed")
                .MaximumLength(10).WithMessage("ZipCode exceeds the authorized size 10");
        }
    }
}
