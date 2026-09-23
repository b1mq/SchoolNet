using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolNet.Application.Dtos.ScheduleDtos
{
    public sealed record UpdateSheduleDto(TimeOnly NewStartTime, TimeOnly NewEndTime) { };
}
