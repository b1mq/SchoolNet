using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolNet.Application.Dtos.HomeworkDto
{
    public sealed record CreateHomeworkDto(string Title, string Content, int ClassSubjectId, int TeacherId, DateTime DueDate);
}
