using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SchoolNet.Application.Dtos.ClassSubjectDtos;
using SchoolNet.Application.Dtos.SchoolClassDtos;
using SchoolNet.Application.Dtos.UserDtos;
using SchoolNet.Application.Feauteres.SchoolClasses.Queries.GetAllClasses;
using SchoolNet.Domain.Entities.Pattern_Repository;
using SchoolNet.Domain.Interfaces.Repository;

namespace SchoolNet.Application.Feauteres.SchoolClasses.Queries.GetAllClassesWithDetails
{
    public sealed class GetAllClassesDetailsQueryHandler : IRequestHandler<GetAllClassesDetailsQuery, ResultGeneric<IReadOnlyCollection<SchoolClassDetailsDto>>>
    {
        private readonly ISchoolClassRepository _schoolClassRepository;

        public GetAllClassesDetailsQueryHandler(ISchoolClassRepository schoolClassRepository)
        {
            _schoolClassRepository = schoolClassRepository;
        }
        public async Task<ResultGeneric<IReadOnlyCollection<SchoolClassDetailsDto>>> Handle(GetAllClassesDetailsQuery request, CancellationToken cancellationToken = default)
        {
            var allClasses = await _schoolClassRepository.GetAllAsync(cancellationToken);
            if (allClasses == null)
            {
                return ResultGeneric<IReadOnlyCollection<SchoolClassDetailsDto>>.Success(new List<SchoolClassDetailsDto>());
            }
            var classesDto = allClasses.Select(c => new SchoolClassDetailsDto(
                 c.Id,
                 c.Name,
                 c.SchoolYear,
                
                 c.Students.Select(s => new UserDto(
                     s.Id,
                     s.FirstName,
                     s.LastName,
                     s.DateOfBirth,
                     s.Age,
                     s.Role,
                     s.ClassId,
                     s.Email)).ToList(),

                 c.ClassSubjects.Select(cs => new ClassSubjectDto(
                     cs.Id,
                     cs.ClassId,
                     cs.SubjectId
                 )).ToList()
             )).ToList();
            return ResultGeneric<IReadOnlyCollection<SchoolClassDetailsDto>>.Success(classesDto);
        }
    }
}
