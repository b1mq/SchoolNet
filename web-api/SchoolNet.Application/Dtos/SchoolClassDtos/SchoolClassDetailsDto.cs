using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Application.Dtos.ClassSubjectDtos;
using SchoolNet.Application.Dtos.UserDtos;

namespace SchoolNet.Application.Dtos.SchoolClassDtos
{
    public sealed record SchoolClassDetailsDto(int Id, string Name, string Year, IReadOnlyCollection<UserDto> StudentsDto, IReadOnlyCollection<ClassSubjectDto> Classsubjects) { };
   
}
