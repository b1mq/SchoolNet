using MediatR;
using SchoolNet.Application.Dtos.SubjectDtos;
using SchoolNet.Domain.Entities.Pattern_Repository;
using SchoolNet.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolNet.Application.Feauteres.Subjects.Queries.GetAllSubjects
{
    public sealed  class GetAllSubjectsQueryHandler:IRequestHandler<GetAllSubjectsQuery,ResultGeneric<IReadOnlyCollection<SubjectDto>> {
        private readonly ISubjectRepository _subjectRepository;
        public GetAllSubjectsQueryHandler(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        public async Task<ResultGeneric<IReadOnlyCollection<SubjectDto>>> Handle(GetAllSubjectsQuery request,CancellationToken cancellationToken = default)
        {
            var subjects = await _subjectRepository.GetAllAsync(cancellationToken);
            var subjectsDto = subjects.Select(s => new SubjectDto(s.Id, s.Title)).ToList();
            return ResultGeneric<IReadOnlyCollection<SubjectDto>>.Success(subjectsDto);
        }
    }
    
    
}
