using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SchoolNet.Domain.Entities.Pattern_Repository;
using SchoolNet.Domain.Interfaces.Repository;
using SchoolNet.Domain.Interfaces.Repository.CommonRepositories;

namespace SchoolNet.Application.Feauteres.SchoolClasses.Commands.RemoveStudentsFromClass
{
    public sealed class RemoveStudentCommandHandler:IRequestHandler<RemoveStudentCommand,Result>
    {
        private readonly ISchoolClassRepository _schoolClassRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RemoveStudentCommandHandler(ISchoolClassRepository schoolClassRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _schoolClassRepository = schoolClassRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(RemoveStudentCommand request,CancellationToken cancellationToken = default)
        {
            var student = await _userRepository.GetEntityById(request.StudentId, cancellationToken);
            if(student == null || student.isDeleted || student.ClassId != request.ClassId)
            {
                return Result.Failure("Student does not exists");

            }
            var schoolClass = await _schoolClassRepository.GetEntityById(request.ClassId, cancellationToken);
            if(schoolClass == null)
            {
                return Result.Failure("This Class does not exist");
            }
            var tryToRemove = schoolClass.RemoveStudent(student);
            if(!tryToRemove.IsSuccess)
            {
                return Result.Failure("Something went wrong check all data and try again");
            }
            _schoolClassRepository.Update(schoolClass);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Succes();
        }
    }
}
