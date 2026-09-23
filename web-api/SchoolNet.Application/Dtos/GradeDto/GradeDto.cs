using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolNet.Application.Dtos.GradeDtos
{
    public sealed record GradeDto(int Id, string Value, string? Comment, int TeacherId, int ClassSubjectId, int StudentId) { };
}
