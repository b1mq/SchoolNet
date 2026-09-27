using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SchoolNet.Application.Dtos.ClassSubjectDtos;
using SchoolNet.Application.Dtos.SchoolClassDtos;
using SchoolNet.Application.Dtos.UserDtos;
using SchoolNet.Domain.Entities.Pattern_Repository;
using SchoolNet.Domain.Interfaces.Repository;

namespace SchoolNet.Application.Feauteres.SchoolClasses.Queries.GetClassDetails
{
    public  sealed class GetClassQueryCommandHandler:IRequestHandler<GetClassDetailQuery,ResultGeneric<SchoolClassDetailsDto>>
    {
        private readonly ISchoolClassRepository _schoolClassRepository;

        public GetClassQueryCommandHandler(ISchoolClassRepository schoolClassRepository)
        {
            _schoolClassRepository = schoolClassRepository;
        }
        public async Task<ResultGeneric<SchoolClassDetailsDto>> Handle(GetClassDetailQuery request,CancellationToken cancellationToken =default)
        {
            var c = await _schoolClassRepository.GetByIdWithDetailsAsync(request.ClassId);
            if (c == null)
            {
                return ResultGeneric<SchoolClassDetailsDto>.Failure("Class not found");
            }
            var classDetailDto = new SchoolClassDetailsDto(c.Id,
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
                     s.Email)).ToList()??new List<UserDto>(),

                 c.ClassSubjects.Select(cs => new ClassSubjectDto(
                     cs.Id,
                     cs.ClassId,
                     cs.SubjectId
                 )).ToList() ?? new List<ClassSubjectDto>());
            return ResultGeneric<SchoolClassDetailsDto>.Success(classDetailDto);
        }
    }
}
