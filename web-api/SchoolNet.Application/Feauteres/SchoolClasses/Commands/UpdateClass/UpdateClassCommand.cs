using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SchoolNet.Domain.Entities.Pattern_Repository;

namespace SchoolNet.Application.Feauteres.SchoolClasses.Commands.UpdateClass
{
    public sealed record UpdateClassCommand(string Name, string Year, int ClassId) : IRequest<Result>;
}
