using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using SchoolNet.Application.Dtos.AbwesenheitDto;

namespace SchoolNet.Application.Validation.AbwesenheitValidation
{
    public sealed class CreateAbwesenheitValidator
    : AbstractValidator<CreateAbwesenheitDto>
    {
        public CreateAbwesenheitValidator()
        {
            RuleFor(x => x.StudentId)
                .GreaterThan(0)
                .WithMessage("Student ID must be greater than zero.");

            RuleFor(x => x.ScheduleId)
                .GreaterThan(0)
                .WithMessage("Schedule ID must be greater than zero.");

            RuleFor(x => x.Date)
                .NotEmpty()
                .WithMessage("Date is required.");

            RuleFor(x => x.Reason)
                .MaximumLength(500)
                .WithMessage("Reason must not exceed 500 characters.");

            RuleFor(x => x.Status)
                .IsInEnum()
                .WithMessage("Invalid absence status.");
        }
    }
}
