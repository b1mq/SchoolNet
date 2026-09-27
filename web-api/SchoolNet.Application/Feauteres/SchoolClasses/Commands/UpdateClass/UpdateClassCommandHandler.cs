using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SchoolNet.Domain.Entities.Pattern_Repository;
using SchoolNet.Domain.Interfaces.Repository;
using SchoolNet.Domain.Interfaces.Repository.CommonRepositories;

namespace SchoolNet.Application.Feauteres.SchoolClasses.Commands.UpdateClass
{
    public sealed class UpdateClassCommandHandler : IRequestHandler<UpdateClassCommand, Result>
    {
        private readonly ISchoolClassRepository _schoolClassRepository;

        private readonly IUnitOfWork _unitOfWork;
        public UpdateClassCommandHandler(ISchoolClassRepository schoolClassRepository, IUnitOfWork unitOfWork)
        {
            _schoolClassRepository = schoolClassRepository;

            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(UpdateClassCommand request, CancellationToken cancellationToken = default)
        {
            var schoolClass = await _schoolClassRepository.GetEntityById(request.ClassId, cancellationToken);
            if (schoolClass == null)
            {
                return Result.Failure("This class does not exists");
            }
            var tryToUpdate = schoolClass.UpdateDetails(request.Name, request.Year);
            if (!tryToUpdate.IsSuccess)
            {
                return Result.Failure(tryToUpdate.Error!);
            }
            _schoolClassRepository.Update(schoolClass);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Succes();
        }
    }
}
