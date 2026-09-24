using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SchoolNet.Domain.Entities.Pattern_Repository;

namespace SchoolNet.Application.Feauteres.Subjects.CreateSubject
{
    public sealed record CreateSubjectCommand(string Title) : IRequest<Result>;
}
