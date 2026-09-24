using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SchoolNet.Application.Interfaces.IHasher;
using SchoolNet.Domain.Entities;
using SchoolNet.Domain.Entities.Pattern_Repository;
using SchoolNet.Domain.Interfaces.Repository;
using SchoolNet.Domain.Interfaces.Repository.CommonRepositories;

namespace SchoolNet.Application.Feauteres.Auth.Commands.Register
{
    public class RegisterCommandHandler:IRequestHandler<RegisterCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IHasherService _hashService;
        private readonly IUnitOfWork _unitOfWork;
        public RegisterCommandHandler(IUserRepository userRepository, IHasherService hashService, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _hashService = hashService;
            _unitOfWork = unitOfWork;
        }
        public async Task<ResultGeneric<int>> Handle(RegisterCommand request,CancellationToken cancellationToken = default  )
        {
            var existUser = await _userRepository.ExistsUserByEmailAsync(request.Email, cancellationToken);
            if(existUser)
            {
                return ResultGeneric<int>.Failure("User with this email is already exists");
            }
            var passwordHasher = _hashService.HashPassword(request.Password);
            var userResult = User.Create(request.FirstName, request.LastName, request.DateOfBirth, passwordHasher, request.Role, request.Email);
            if(!userResult.IsSuccess)
            {
                return ResultGeneric<int>.Failure(userResult.Error);
            }
            _userRepository.Add(userResult.Value,cancellationToken);
            await _unitOfWork.SaveChangesAsync();
            return ResultGeneric<int>.Success(userResult.Value.Id);
        }
    }
}
