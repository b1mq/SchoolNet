using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MediatR;
using SchoolNet.Application.Dtos.GradeDtos;
using SchoolNet.Domain.Entities.Pattern_Repository;
using SchoolNet.Domain.Interfaces.Repository;

namespace SchoolNet.Application.Feauteres.Grades.Queries.GetStudentGrades
{
    public class StudentGradesQueryHandler : IRequestHandler<StudentGradesQuery, ResultGeneric<IReadOnlyCollection<GradeDto>>>
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IUserRepository _userRepository;
        public StudentGradesQueryHandler(IGradeRepository gradeRepository, IUserRepository userRepository)
        {
            _gradeRepository = gradeRepository;
            _userRepository = userRepository;
        }
        public async Task<ResultGeneric<IReadOnlyCollection<GradeDto>>> Handle(StudentGradesQuery request,CancellationToken cancellationToken = default)
        {
            var usersExists = await  _userRepository.GetEntityById(request.StudentId,cancellationToken);
            if(usersExists == null || usersExists.Role != Domain.Enums.UserRole.Student || usersExists.isDeleted)
            {
                return ResultGeneric<IReadOnlyCollection<GradeDto>>.Failure("Student not found.");
            }
            var grades = await _gradeRepository.GetByStudentIdAsync(request.StudentId,cancellationToken);
            var gradesDtos = grades.Select(g => new GradeDto(
                g.Id,
                g.Value,
                g.Comment,
                g.TeacherId,
                g.ClassSubjectId,
                g.StudentId)).ToList();
            return ResultGeneric<IReadOnlyCollection<GradeDto>>.Success(gradesDtos);
        }
    }
}
