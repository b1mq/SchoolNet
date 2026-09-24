using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SchoolNet.Domain.Entities.Pattern_Repository;
using SchoolNet.Domain.Interfaces.Repository;
using SchoolNet.Domain.Interfaces.Repository.CommonRepositories;

namespace SchoolNet.Application.Feauteres.SchoolClasses.Commands.AssignStudentToClass
{
    public sealed class AssignStudentCommandHandler:IRequestHandler<AssignStudentCommand,Result>
    {
        private readonly IUserRepository _userRepository;
        private readonly ISchoolClassRepository _classRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AssignStudentCommandHandler(IUserRepository userRepository, ISchoolClassRepository classRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _classRepository = classRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(AssignStudentCommand request,CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.GetUserByIdAsync(request.StudentId);
            if(user == null || user.Role != Domain.Enums.UserRole.Student)
            {
                return Result.Failure("This student is not exists OR User is not Student");
            }
            var schoolClass = await _classRepository.GetEntityById(request.ClassId);
            if(schoolClass == null)
            {
                return Result.Failure("This class is does not exists");
            }
            var assign = user.AssignToClass(request.ClassId);
            if(!assign.IsSuccess)
            {
                return Result.Failure(assign.Error);
            }
            _userRepository.Update(user);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Succes();
        }
    }
}
