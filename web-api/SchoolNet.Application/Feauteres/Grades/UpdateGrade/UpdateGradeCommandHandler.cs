using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SchoolNet.Domain.Entities.Pattern_Repository;
using SchoolNet.Domain.Interfaces.Repository;
using SchoolNet.Domain.Interfaces.Repository.CommonRepositories;

namespace SchoolNet.Application.Feauteres.Grades.UpdateGrade
{
    public sealed class UpdateGradeCommandHandler:IRequestHandler<UpdateGradeCommand,Result>
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateGradeCommandHandler(IGradeRepository repo, IUnitOfWork unitOfWork)
        {
            _gradeRepository = repo;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(UpdateGradeCommand request,CancellationToken cancellationToken = default)
        {
            var Grade = await _gradeRepository.GetEntityById(request.GradeId);
            if(Grade == null || Grade.isDeleted)
            {
                return Result.Failure("Grade Not Found" );
            }
            var updateRequest = Grade.UpdateGrade(request.Value);
            if(!updateRequest.IsSuccess)
            {
                return Result.Failure(updateRequest.Error!);
            }
            if(!string.IsNullOrWhiteSpace(request.Comment))
            {
                var commentResult = Grade.AddComment(request.Comment);
                if(!commentResult.IsSuccess)
                {
                    return Result.Failure(commentResult.Error!);
                }
            }
            _gradeRepository.Update(Grade);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Succes();

        }
    }
}
