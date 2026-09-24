using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using MediatR;
using SchoolNet.Application.Dtos.Auth;
using SchoolNet.Application.Dtos.UserDtos;
using SchoolNet.Application.Interfaces.Auth;
using SchoolNet.Application.Interfaces.IHasher;
using SchoolNet.Domain.Entities.Pattern_Repository;
using SchoolNet.Domain.Interfaces.Repository;
using SchoolNet.Domain.Interfaces.Repository.CommonRepositories;

namespace SchoolNet.Application.Feauteres.Auth.Commands.Login
{
   public sealed class LoginCommandHandler: IRequestHandler<LoginCommand, ResultGeneric<LoginResponseDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IHasherService _hashService;
        private readonly IJwtOptionsProvider _jwt;
        private readonly IUnitOfWork _unit;
        public LoginCommandHandler(IUserRepository userRepository,IHasherService hasherService,IJwtOptionsProvider jwtProvider,IUnitOfWork unit)
        {
            _userRepository = userRepository;
            _hashService = hasherService;
            _jwt = jwtProvider;
            _unit = unit;
        }
        public async Task<ResultGeneric<LoginResponseDto>> Handle(LoginCommand request,CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if(user == null)
            {
                return ResultGeneric<LoginResponseDto>.Failure("Invalid email or password");
            }
            if(!_hashService.VerifyPassword(request.Password,user.PasswordHash))
            {
                return ResultGeneric<LoginResponseDto>.Failure("Password is incorrect");
            }
            var accessToken = _jwt.GenerateAccessToken(user);
            var refreshToken = _jwt.GenerateRefreshToken();
            user.UpdateRefreshToken(_hashService.HashPassword(accessToken), DateTime.UtcNow.AddDays(7));
             _userRepository.Update(user);
            await _unit.SaveChangesAsync(cancellationToken);
            var userDto = new UserDto
            (
                user.Id,
                user.FirstName,
                user.LastName,
                user.DateOfBirth,
                user.Age,
                user.Role,
                user.ClassId,
                user.Email

                
            );
            var response  = new LoginResponseDto(accessToken,refreshToken,userDto);
            return ResultGeneric<LoginResponseDto>.Success(response);
        }
    }
}
