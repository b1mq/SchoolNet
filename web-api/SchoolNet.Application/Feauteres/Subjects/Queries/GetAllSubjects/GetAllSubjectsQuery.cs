using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MediatR.Entities;
using SchoolNet.Application.Dtos.SubjectDtos;
using SchoolNet.Domain.Entities.Pattern_Repository;
namespace SchoolNet.Application.Feauteres.Subjects.Queries.GetAllSubjects
{
    public sealed record GetAllSubjectsQuery() : IRequest<ResultGeneric<IReadOnlyCollection<SubjectDto>>>;
    
    
}
