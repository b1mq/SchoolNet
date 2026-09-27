using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SchoolNet.Domain.Entities.Pattern_Repository;
using SchoolNet.Domain.Interfaces.Repository;
using SchoolNet.Domain.Interfaces.Repository.CommonRepositories;

namespace SchoolNet.Application.Feauteres.Grades.DeleteGrade
{
    public sealed class DeleteGradeCommandHandler:IRequestHandler<DeleteGradeCommand,Result>
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteGradeCommandHandler(IGradeRepository gradeRepository, IUnitOfWork unitOfWork)
        {
            _gradeRepository = gradeRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(DeleteGradeCommand command,CancellationToken cancellationToken = default)
        {
            var Grade = await _gradeRepository.GetEntityById(command.GradeId);
            if(Grade == null)
            {
                return Result.Failure("Grade is not found");
            }
            Grade.SoftDelete();
            _gradeRepository.Update(Grade);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Succes();

        }
    }
}
