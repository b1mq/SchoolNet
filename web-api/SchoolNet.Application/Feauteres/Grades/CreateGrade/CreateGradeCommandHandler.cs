using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SchoolNet.Domain.Entities.Pattern_Repository;
using SchoolNet.Domain.Entities.Spec;
using SchoolNet.Domain.Interfaces.Repository;
using SchoolNet.Domain.Interfaces.Repository.CommonRepositories;

namespace SchoolNet.Application.Feauteres.Grades.AssignGrade
{
    public sealed class CreateGradeCommandHandler:IRequestHandler<CreateGradeCommand,ResultGeneric<int>>
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateGradeCommandHandler(IGradeRepository repo,IUnitOfWork unitOfWork)
        {
            _gradeRepository = repo;
            _unitOfWork = unitOfWork;
        }
        public async Task<ResultGeneric<int>> Handle(CreateGradeCommand request,CancellationToken cancellationToken = default)
        {
            var newGrade = Grade.Create(request.Value, request.Comment, request.TeacherId, request.ClassSubjectId, request.StudentId);
            if(!newGrade.IsSuccess)
            {
                return ResultGeneric<int>.Failure(newGrade.Error!);
            }
            _gradeRepository.Add(newGrade.Value!);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return ResultGeneric<int>.Success(newGrade.Value!.Id);
        }
    }
}
