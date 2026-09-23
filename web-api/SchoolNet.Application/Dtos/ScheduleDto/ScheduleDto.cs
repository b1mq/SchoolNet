using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolNet.Application.Dtos.ScheduleDtos
{
    public sealed record ScheduleDto(int Id, int ClassSubjectId, int TeacherId, DayOfWeek DayOfWeek, int? RoomId, TimeOnly StartTime, TimeOnly EndTime) { };
}
