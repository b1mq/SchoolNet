using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolNet.Application.Dtos.GradeDtos
{
    public sealed record UpdateGradeDto(string Value, string? Comment);
    
}
