using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using SchoolNet.Application.Dtos.ClassSubjectDtos;

namespace SchoolNet.Application.Validation.ClassSubject
{
    public sealed class CreateClassSubjectValidator
    : AbstractValidator<CreateClassSubjectDto>
    {
        public CreateClassSubjectValidator()
        {
            RuleFor(x => x.ClassId)
                .GreaterThan(0)
                .WithMessage("Class ID must be greater than zero.");

            RuleFor(x => x.SubjectId)
                .GreaterThan(0)
                .WithMessage("Subject ID must be greater than zero.");
        }
    }
}
