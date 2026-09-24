using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SchoolNet.Domain.Entities;
using SchoolNet.Domain.Entities.Pattern_Repository;
using SchoolNet.Domain.Interfaces.Repository;
using SchoolNet.Domain.Interfaces.Repository.CommonRepositories;

namespace SchoolNet.Application.Feauteres.SchoolClasses.Commands.CreateClass
{
    public sealed class CreateClassCommandHandler:IRequestHandler<CreateSchoolClassCommand,ResultGeneric<int>>
    {
        private readonly ISchoolClassRepository _classRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateClassCommandHandler(ISchoolClassRepository classRepository, IUnitOfWork unitOfWork)
        {
            _classRepository = classRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<ResultGeneric<int>> Handle(CreateSchoolClassCommand request,CancellationToken cancellationToken = default)
        {
            var newClass = SchoolClass.Create(request.Name, request.Year);
            if(!newClass.IsSuccess)
            {
                return ResultGeneric<int>.Failure(newClass.Error);
            }
            _classRepository.Add(newClass.Value);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return ResultGeneric<int>.Success(newClass.Value.Id);
        }
    }
}
