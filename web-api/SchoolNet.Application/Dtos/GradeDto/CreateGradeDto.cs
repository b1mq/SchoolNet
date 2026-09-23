using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolNet.Application.Dtos.GradeDtos
{
    public sealed record CreateGradeDto(string Value, string? Comment, int TeacherId, int ClassSubjectId, int StudentId) { };
}
