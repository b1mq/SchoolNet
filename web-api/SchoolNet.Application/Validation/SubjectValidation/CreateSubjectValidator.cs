using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using SchoolNet.Application.Dtos.SubjectDtos;

namespace SchoolNet.Application.Validation.SubjectValidation
{
    public sealed class CreateSubjectValidator
    : AbstractValidator<CreateSubjectDto>
    {
        public CreateSubjectValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Subject title is required.")
                .MaximumLength(100)
                .WithMessage("Subject title must not exceed 100 characters.");
        }
    }
}
