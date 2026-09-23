using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using SchoolNet.Application.Dtos.Common;

namespace SchoolNet.Application.Validation.Common
{
    public sealed class PaginationRequestValidator
    : AbstractValidator<PaginationRequestDto>
    {
        public PaginationRequestValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Page must be greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .InclusiveBetween(1, 100)
                .WithMessage("Page size must be between 1 and 100.");
        }
    }
}
