using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SchoolNet.Domain.Entities.Pattern_Repository;

namespace SchoolNet.Application.Feauteres.Auth.Commands.ChangePassword
{
    public sealed record ChangePasswordCommand(int UserId, string oldPassword, string NewPassword) : IRequest<Result>;
}
