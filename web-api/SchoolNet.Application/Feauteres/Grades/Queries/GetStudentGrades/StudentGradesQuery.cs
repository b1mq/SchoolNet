using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MediatR;
using SchoolNet.Application.Dtos.GradeDtos;
using SchoolNet.Domain.Entities.Pattern_Repository;
using SchoolNet.Domain.Entities.Spec;

namespace SchoolNet.Application.Feauteres.Grades.Queries.GetStudentGrades
{
    public sealed record StudentGradesQuery(int StudentId) : IRequest<ResultGeneric<IReadOnlyCollection<GradeDto>>>;
}
