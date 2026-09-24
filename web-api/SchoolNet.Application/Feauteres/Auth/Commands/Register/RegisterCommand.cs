using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SchoolNet.Domain.Entities.Pattern_Repository;
using SchoolNet.Domain.Enums;

namespace SchoolNet.Application.Feauteres.Auth.Commands.Register
{
    public sealed record RegisterCommand(string FirstName, string LastName, DateOnly DateOfBirth, string Email, string Password, UserRole Role) : IRequest<ResultGeneric<int>>;
}
