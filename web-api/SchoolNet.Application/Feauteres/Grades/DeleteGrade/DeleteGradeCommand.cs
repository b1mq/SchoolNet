using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SchoolNet.Domain.Entities.Pattern_Repository;

namespace SchoolNet.Application.Feauteres.Grades.DeleteGrade
{

    public sealed record DeleteGradeCommand(int GradeId) : IRequest<Result>;
}
