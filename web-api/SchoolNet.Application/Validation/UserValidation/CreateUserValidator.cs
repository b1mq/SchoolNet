using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using SchoolNet.Application.Dtos.UserDtos;

namespace SchoolNet.Application.Validation.UserValidation
{
    public sealed class CreateUserValidator
    : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Firstname)
                .NotEmpty()
                .WithMessage("First name is required.")
                .MaximumLength(50)
                .WithMessage("First name must not exceed 50 characters.");

            RuleFor(x => x.Surname)
                .NotEmpty()
                .WithMessage("Last name is required.")
                .MaximumLength(50)
                .WithMessage("Last name must not exceed 50 characters.");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty()
                .WithMessage("Date of birth is required.")
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow))
                .WithMessage("Date of birth cannot be in the future.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Email must be a valid email address.")
                .MaximumLength(254)
                .WithMessage("Email must not exceed 254 characters.");

            RuleFor(x => x.Role)
                .IsInEnum()
                .WithMessage("Invalid user role.");
        }
    }
}
