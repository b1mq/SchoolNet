using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SchoolNet.Domain.Entities.Pattern_Repository;

namespace SchoolNet.Application.Feauteres.Grades.UpdateGrade
{
    public sealed record UpdateGradeCommand(int GradeId, string Value, string? Comment) : IRequest<Result>;
}
