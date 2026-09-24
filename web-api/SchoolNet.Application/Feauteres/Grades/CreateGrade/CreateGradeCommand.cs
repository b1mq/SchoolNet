using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SchoolNet.Domain.Entities.Pattern_Repository;

namespace SchoolNet.Application.Feauteres.Grades.AssignGrade
{
    public sealed record CreateGradeCommand(string Value, string? Comment, int TeacherId, int ClassSubjectId, int StudentId) : IRequest<ResultGeneric<int>>;
}
