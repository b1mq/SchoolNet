using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SchoolNet.Application.Dtos.Auth;
using SchoolNet.Application.Dtos.UserDtos;
using SchoolNet.Application.Interfaces.Auth;
using SchoolNet.Application.Interfaces.IHasher;
using SchoolNet.Domain.Entities.Pattern_Repository;
using SchoolNet.Domain.Interfaces.Repository;
using SchoolNet.Domain.Interfaces.Repository.CommonRepositories;

namespace SchoolNet.Application.Feauteres.Auth.Commands.RefreshToken
{
    public sealed class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, ResultGeneric<LoginResponseDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IHasherService _hashService;
        private readonly IJwtOptionsProvider _jwtProvider;
        private readonly IUnitOfWork _unitOfWork;
        public RefreshTokenCommandHandler(IUserRepository userRepository, IHasherService hashService, IJwtOptionsProvider jwtProvider, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _hashService = hashService;
            _jwtProvider = jwtProvider;
            _unitOfWork = unitOfWork;
        }
        public async Task<ResultGeneric<LoginResponseDto>> Handle(RefreshTokenCommand request,CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.GetUserByIdAsync(request.UserId);
            if(user == null)
            {
                return ResultGeneric<LoginResponseDto>.Failure("This user does not exists");

            }
            if(user.RefreshTokenExpiryTime == null || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                return ResultGeneric<LoginResponseDto>.Failure("RefreshToken has expired please login ");
            }
            if(!_hashService.VerifyPassword(request.RefreshToken, user.RefreshTokenHash))
            {
                return ResultGeneric<LoginResponseDto>.Failure("Invalid refresh token");
            }
            var newToken = _jwtProvider.GenerateAccessToken(user);
            var newRefreshToken = _jwtProvider.GenerateRefreshToken();
            user.UpdateRefreshToken(_hashService.HashPassword(newToken), DateTime.UtcNow.AddDays(7));
            _userRepository.Update(user);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            var UserDto = new UserDto(user.Id, user.FirstName, user.LastName, user.DateOfBirth, user.Age, user.Role, user.ClassId, user.Email);
            var response = new LoginResponseDto(newToken, newRefreshToken,UserDto);
            return ResultGeneric<LoginResponseDto>.Success(response);
        }
    }
}
