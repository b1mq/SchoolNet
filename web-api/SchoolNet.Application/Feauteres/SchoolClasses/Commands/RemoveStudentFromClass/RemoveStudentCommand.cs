using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SchoolNet.Domain.Entities.Pattern_Repository;

namespace SchoolNet.Application.Feauteres.SchoolClasses.Commands.RemoveStudentsFromClass
{
    public sealed record RemoveStudentCommand(int StudentId,int ClassId) : IRequest<Result>;
}
