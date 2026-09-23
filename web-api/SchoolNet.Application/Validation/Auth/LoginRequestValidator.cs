using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using SchoolNet.Application.Dtos.Auth;

namespace SchoolNet.Application.Validation.Auth
{
    public sealed class LoginRequestValidator:AbstractValidator<LoginRequestDto>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Email must be a valid email address.")
            .MaximumLength(254)
            .WithMessage("Email must not exceed 254 characters.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.");
        }
    }
}
