using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SchoolNet.Domain.Entities;
using SchoolNet.Domain.Entities.Pattern_Repository;
using SchoolNet.Domain.Interfaces.Repository;
using SchoolNet.Domain.Interfaces.Repository.CommonRepositories;

namespace SchoolNet.Application.Feauteres.Subjects.Commands.AssignSubjectToClass
{
    public sealed class AssignSubjectToClassCommandHandler:IRequestHandler<AssignSubjectToClassCommand,ResultGeneric<int>>
    {
        private readonly ISchoolClassRepository _classRepository;
        private readonly ISubjectRepository _subjectRepository;
  
        private readonly IClassSubjectRepository _classSubjectRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AssignSubjectToClassCommandHandler(
            ISchoolClassRepository classRepository,
            ISubjectRepository subjectRepository,
        
            IClassSubjectRepository classSubjectRepository,
            IUnitOfWork unitOfWork)
        {
            _classRepository = classRepository;
            _subjectRepository = subjectRepository;
          
            _classSubjectRepository = classSubjectRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<ResultGeneric<int>> Handle(AssignSubjectToClassCommand request,CancellationToken cancellationToken = default)
        {
            var schoolClass = await _classRepository.GetEntityById(request.ClassId, cancellationToken);
           
            var subject = await _subjectRepository.GetEntityById(request.SubjectId, cancellationToken);
            if(schoolClass == null || schoolClass.isDeleted)
            {
                return ResultGeneric<int>.Failure("This class does not exists");
            }
           
            if(subject == null||subject.isDeleted )
            {
                return ResultGeneric<int>.Failure("This subject does not exists");
            }
            var classSubjectRequest = ClassSubject.Create(request.ClassId, request.SubjectId);
            if (!classSubjectRequest.IsSuccess)
            {
                return ResultGeneric<int>.Failure(classSubjectRequest.Error!);
            }
            _classSubjectRepository.Add(classSubjectRequest.Value!);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return ResultGeneric<int>.Success(classSubjectRequest.Value!.Id);
        }
            
    }
}
