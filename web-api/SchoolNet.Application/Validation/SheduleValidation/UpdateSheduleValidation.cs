using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using SchoolNet.Application.Dtos.ScheduleDtos;

namespace SchoolNet.Application.Validation.SheduleValidation
{
    public sealed class UpdateSheduleValidator
    : AbstractValidator<UpdateSheduleDto>
    {
        public UpdateSheduleValidator()
        {
            RuleFor(x => x.NewStartTime)
                .NotEmpty()
                .WithMessage("Start time is required.");

            RuleFor(x => x.NewEndTime)
                .NotEmpty()
                .WithMessage("End time is required.")
                .GreaterThan(x => x.NewStartTime)
                .WithMessage("End time must be greater than start time.");
        }
    }
}
