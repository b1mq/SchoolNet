using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SchoolNet.Application.Dtos.SchoolClassDtos;
using SchoolNet.Domain.Entities;
using SchoolNet.Domain.Entities.Pattern_Repository;
using SchoolNet.Domain.Interfaces.Repository;

namespace SchoolNet.Application.Feauteres.SchoolClasses.Queries.GetAllClasses
{
    public sealed class GetAllClassesQueryHandler:IRequestHandler<GetAllClassesQuery,ResultGeneric<IReadOnlyCollection<SchoolClassDto>>>
    {
        private readonly ISchoolClassRepository _schoolClassRepository;

        public GetAllClassesQueryHandler(ISchoolClassRepository schoolClassRepository)
        {
            _schoolClassRepository = schoolClassRepository;
        }
        public async Task<ResultGeneric<IReadOnlyCollection<SchoolClassDto>>> Handle(GetAllClassesQuery request,CancellationToken cancellationToken = default)
        {
            var allClasses = await _schoolClassRepository.GetAllAsync(cancellationToken);
            if(allClasses == null)
            {
                return ResultGeneric<IReadOnlyCollection<SchoolClassDto>>.Success(new List<SchoolClassDto>());
            }
            var classesDto = allClasses.Select(c => new SchoolClassDto(c.Id, c.Name, c.SchoolYear)).ToList();
            return ResultGeneric<IReadOnlyCollection<SchoolClassDto>>.Success(classesDto);
        }
    }
}
