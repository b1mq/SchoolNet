using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SchoolNet.Domain.Entities.Pattern_Repository;

namespace SchoolNet.Application.Feauteres.Subjects.Commands.AssignSubjectToClass
{
    public sealed record AssignSubjectToClassCommand(int ClassId, int SubjectId) : IRequest<ResultGeneric<int>;
}
