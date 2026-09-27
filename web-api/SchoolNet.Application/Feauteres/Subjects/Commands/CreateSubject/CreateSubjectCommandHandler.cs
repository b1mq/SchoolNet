using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SchoolNet.Domain.Entities;
using SchoolNet.Domain.Entities.Pattern_Repository;
using SchoolNet.Domain.Interfaces.Repository;
using SchoolNet.Domain.Interfaces.Repository.CommonRepositories;

namespace SchoolNet.Application.Feauteres.Subjects.Commands.CreateSubject
{
    public sealed class CreateSubjectCommandHandler:IRequestHandler<CreateSubjectCommand,Result>
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSubjectCommandHandler(ISubjectRepository subjectRepository, IUnitOfWork unitOfWork)
        {
            _subjectRepository = subjectRepository;
            _unitOfWork  = unitOfWork;
        }
        public async Task<Result> Handle(CreateSubjectCommand command,CancellationToken cancellationToken = default)
        {
            var newsubject = Subject.Create(command.Title);
            if(!newsubject.IsSuccess)
            {
                return Result.Failure(newsubject.Error!);
            }
            _subjectRepository.Add(newsubject.Value!,cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Succes();

        }


    }
}
