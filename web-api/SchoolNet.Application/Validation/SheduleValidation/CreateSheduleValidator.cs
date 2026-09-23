using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using SchoolNet.Application.Dtos.ScheduleDtos;

namespace SchoolNet.Application.Validation.SheduleValidation
{
    public sealed class CreateScheduleValidator
    : AbstractValidator<CreateSheduleDto>
    {
        public CreateScheduleValidator()
        {
            RuleFor(x => x.ClassSubjectId)
                .GreaterThan(0)
                .WithMessage("Class subject ID must be greater than zero.");

            RuleFor(x => x.TeacherId)
                .GreaterThan(0)
                .WithMessage("Teacher ID must be greater than zero.");

            RuleFor(x => x.RoomId)
                .GreaterThan(0)
                .When(x => x.RoomId.HasValue)
                .WithMessage("Room ID must be greater than zero.");

            RuleFor(x => x.StartTime)
                .NotEmpty()
                .WithMessage("Start time is required.");

            RuleFor(x => x.EndTime)
                .NotEmpty()
                .WithMessage("End time is required.")
                .GreaterThan(x => x.StartTime)
                .WithMessage("End time must be greater than start time.");
        }
    }
}
