using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolNet.Application.Dtos.ClassSubjectDtos
{
    public sealed record ClassSubjectDto(int Id,int ClassId, int SubjectId) { };
}
