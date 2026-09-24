using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using SchoolNet.Domain.Interfaces.Repository;
using SchoolNet.Infrastructure.Repositories;

namespace SchoolNet.Infrastructure
{
    public static  class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IScheduleRepository, SheduleRepository>();
            services.AddScoped<ISchoolClassRepository, SchoolClassRepository>();
            services.AddScoped<IHomeworkRepository, HomeworkRepository>();
            services.AddScoped<IGradeRepository, GradeRepository>();
            services.AddScoped<IClassSubjectRepository, ClassSubjectRepository>();
            services.AddScoped<IAbwesenheitRepository, AbwesenheitRepository>();
            return services;
        }
    }
}
