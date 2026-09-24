using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolNet.Application.Dtos.HomeworkDto
{
    public sealed record UpdateHomeworkDto(string Title, string Content, DateTime DueDate);
}
