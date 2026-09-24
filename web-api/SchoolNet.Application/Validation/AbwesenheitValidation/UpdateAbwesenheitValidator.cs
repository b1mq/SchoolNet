using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using SchoolNet.Application.Dtos.AbwesenheitDto;

namespace SchoolNet.Application.Validation.AbwesenheitValidation
{
    public sealed class UpdateAbwesenheitValidator
    : AbstractValidator<UpdateAbwesenheitDto>
    {
        public UpdateAbwesenheitValidator()
        {
            RuleFor(x => x.ScheduleId)
                .GreaterThan(0)
                .When(x => x.ScheduleId.HasValue)
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
