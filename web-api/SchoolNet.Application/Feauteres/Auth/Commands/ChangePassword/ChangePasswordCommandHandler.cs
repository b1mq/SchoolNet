using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SchoolNet.Application.Interfaces.IHasher;
using SchoolNet.Domain.Interfaces.Repository;
using SchoolNet.Domain.Interfaces.Repository.CommonRepositories;
using SchoolNet.Domain.Entities.Pattern_Repository;
namespace SchoolNet.Application.Feauteres.Auth.Commands.ChangePassword
{
    public sealed class ChangePasswordCommandHandler:IRequestHandler<ChangePasswordCommand,Result>
    {
        private readonly IUserRepository _userRepository;
        private readonly IHasherService _hashService;
        private readonly IUnitOfWork _unitOfWork;
        public ChangePasswordCommandHandler(IUserRepository userRepository, IHasherService hashService, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _hashService = hashService;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(ChangePasswordCommand request,CancellationToken cancellation = default)
        {
            var user = await _userRepository.GetUserByIdAsync(request.UserId, cancellation);
            if(user == null)
            {
                return Result.Failure("User not found");
            }
            if(!_hashService.VerifyPassword(request.oldPassword,user.PasswordHash))
            {
                return Result.Failure("Old password is incorrect");
            }
            var change = user.UpdatePasswordHash(_hashService.HashPassword(request.NewPassword));
            if(!change.IsSuccess)
            {
                return Result.Failure(change.Error);
            }
            return Result.Succes();
        }
    }
}
