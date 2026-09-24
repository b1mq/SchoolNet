using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SchoolNet.Domain.Entities.Pattern_Repository;

namespace SchoolNet.Application.Feauteres.SchoolClasses.Commands.CreateClass
{
    public sealed record CreateSchoolClassCommand(string Name, string Year) : IRequest<ResultGeneric<int>>;
    

}
