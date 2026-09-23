using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolNet.Application.Dtos.ClassSubjectDtos
{
    public sealed record CreateClassSubjectDto(int ClassSubjectId, int SubjectId) { };
}
