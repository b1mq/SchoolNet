using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SchoolNet.Application.Interfaces.IHasher;
using SchoolNet.Application.Services.PasswordHasher;

namespace SchoolNet.Application
{
    public static  class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection collection)
        {
            collection.AddValidatorsFromAssemblyContaining<ApplicationAssemblyMarker>();
            collection.AddSingleton<IHasherService, PasswordHasher>();
            return collection;
        }
    }
}
