using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MediatR;
using SchoolNet.Application.Dtos.GradeDtos;
using SchoolNet.Domain.Entities.Pattern_Repository;
using SchoolNet.Domain.Interfaces.Repository;

namespace SchoolNet.Application.Feauteres.Grades.Queries.GetClassGradesBySubject
{
    public sealed class ClassGradesQueryHandler:IRequestHandler<ClassGradesQuery,ResultGeneric<IReadOnlyCollection<GradeDto>>>
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IClassSubjectRepository _classSubjectRepository;
        public ClassGradesQueryHandler(IGradeRepository gradeRepository, IClassSubjectRepository classSubjectRepository)
        {
            _gradeRepository = gradeRepository;
            _classSubjectRepository = classSubjectRepository;
        }
        public async Task<ResultGeneric<IReadOnlyCollection<GradeDto>>> Handle(ClassGradesQuery request,CancellationToken cancellationToken = default)
        {
            var existsClassSubject = await _classSubjectRepository.GetEntityById(request.ClassSubjectId,cancellationToken);
            if(existsClassSubject == null)
            {
                return ResultGeneric<IReadOnlyCollection<GradeDto>>.Failure("This class subject does not exists");
            }
            var subjectGrades = await _gradeRepository.GetByClassSubjectIdAsync(request.ClassSubjectId, cancellationToken);
            if (subjectGrades == null)
            {
                return ResultGeneric<IReadOnlyCollection<GradeDto>>.Success(new List<GradeDto>());
            }
            var gradesDto = subjectGrades.Select(s => new GradeDto(s.Id, s.Value, s.Comment, s.TeacherId, s.ClassSubjectId, s.StudentId)).ToList();
            return ResultGeneric<IReadOnlyCollection<GradeDto>>.Success(gradesDto);
        }
    }
}
