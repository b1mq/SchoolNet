using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SchoolNet.Application.Dtos.GradeDtos;
using SchoolNet.Domain.Entities.Pattern_Repository;

namespace SchoolNet.Application.Feauteres.Grades.Queries.GetClassGradesBySubject
{
    public sealed record ClassGradesQuery(int ClassSubjectId, int TeacherId) : IRequest<ResultGeneric<IReadOnlyCollection<GradeDto>>>;
}
