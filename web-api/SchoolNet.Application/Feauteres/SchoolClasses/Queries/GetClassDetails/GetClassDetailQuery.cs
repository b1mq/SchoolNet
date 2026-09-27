using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SchoolNet.Application.Dtos.SchoolClassDtos;
using SchoolNet.Domain.Entities.Pattern_Repository;

namespace SchoolNet.Application.Feauteres.SchoolClasses.Queries.GetClassDetails
{
    public sealed record GetClassDetailQuery(int ClassId) : IRequest<ResultGeneric<SchoolClassDetailsDto>>;
}
