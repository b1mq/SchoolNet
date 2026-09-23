using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using SchoolNet.Application.Dtos.SchoolClassDtos;

namespace SchoolNet.Application.Validation.SchoolClassValidation
{
    public sealed class UpdateSchoolClassValidator
    : AbstractValidator<UpdateSchoolClassDto>
    {
        public UpdateSchoolClassValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Class name is required.")
                .MaximumLength(20)
                .WithMessage("Class name must not exceed 20 characters.");

            RuleFor(x => x.Year)
                .NotEmpty()
                .WithMessage("School year is required.")
                .MaximumLength(20)
                .WithMessage("School year must not exceed 20 characters.");
        }

    }
}
