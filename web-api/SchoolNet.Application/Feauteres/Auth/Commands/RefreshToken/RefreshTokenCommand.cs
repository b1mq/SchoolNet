using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SchoolNet.Application.Dtos.Auth;
using SchoolNet.Domain.Entities.Pattern_Repository;

namespace SchoolNet.Application.Feauteres.Auth.Commands.RefreshToken
{
    public sealed record RefreshTokenCommand(int UserId, string RefreshToken) : IRequest<ResultGeneric<LoginResponseDto>>;
}
