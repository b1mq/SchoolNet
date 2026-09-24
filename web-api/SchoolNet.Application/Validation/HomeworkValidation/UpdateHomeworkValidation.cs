using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using SchoolNet.Application.Dtos.HomeworkDto;

namespace SchoolNet.Application.Validation.HomeworkValidation
{

    public sealed class UpdateHomeworkValidator
        : AbstractValidator<UpdateHomeworkDto>
    {
        public UpdateHomeworkValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is required.")
                .MaximumLength(200)
                .WithMessage("Title must not exceed 200 characters.");

            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Content is required.")
                .MaximumLength(5000)
                .WithMessage("Content must not exceed 5000 characters.");

            RuleFor(x => x.DueDate)
                .NotEmpty()
                .WithMessage("Due date is required.");
        }
    }
}
