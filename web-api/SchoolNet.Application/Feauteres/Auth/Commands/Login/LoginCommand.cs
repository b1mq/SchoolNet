using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SchoolNet.Application.Dtos.Auth;
using SchoolNet.Domain.Entities.Pattern_Repository;

namespace SchoolNet.Application.Feauteres.Auth.Commands.Login
{
    public sealed record LoginCommand(string Email, string Password) : IRequest<ResultGeneric<LoginResponseDto>>;
}
