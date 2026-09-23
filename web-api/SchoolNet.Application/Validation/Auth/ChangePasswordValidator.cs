using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using SchoolNet.Application.Dtos.Auth;

namespace SchoolNet.Application.Validation.Auth
{
    public sealed class ChangePasswordValidator
     : AbstractValidator<ChangePasswordDto>
    {
        public ChangePasswordValidator()
        {
            RuleFor(x => x.Oldpassword)
                .NotEmpty()
                .WithMessage("Old password is required.");

            RuleFor(x => x.Newpassword)
                .NotEmpty()
                .WithMessage("New password is required.")
                .MinimumLength(8)
                .WithMessage("New password must be at least 8 characters long.")
                .MaximumLength(128)
                .WithMessage("New password must not exceed 128 characters.")
                .NotEqual(x => x.Newpassword)
                .WithMessage("New password must be different from the old password.");
        }
    }
}
