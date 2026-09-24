using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Domain.Enums;

namespace SchoolNet.Application.Dtos.AbwesenheitDto
{
    public sealed record CreateAbwesenheitDto(int StudentId, int? ScheduleId, DateTime Date, string? Reason, AbsenceStatus Status);
}
