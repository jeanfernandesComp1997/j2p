using j2p.Domain.Entities;
using j2p.Domain.Interfaces.Repositories;
using j2p.Domain.Interfaces.Services;
using System;

namespace j2p.Domain.Services
{
    public class OwnerService : ServiceBase<Owner>, IOwnerService
    {
        private readonly IUoWRepository _unitOfWork;

        public OwnerService(IUoWRepository unitOfWork) : base(unitOfWork.OwnerRepository)
        {
            _unitOfWork = unitOfWork;
        }

        public Owner Save(Owner obj)
        {
            obj.Validate();

            _unitOfWork.BeginTransaction();
            _unitOfWork.OwnerRepository.Add(obj);
            _unitOfWork.Commit();

            return obj;
        }

        public void Delete(Guid id)
        {
            Owner owner = _unitOfWork.OwnerRepository.GetById(id);

            if (owner == null)
                throw new Exception("Owner não encontrado");

            _unitOfWork.BeginTransaction();
            _unitOfWork.OwnerRepository.Delete(owner);
            _unitOfWork.Commit();
        }

        public Owner Update(Owner obj)
        {
            obj.Validate();

            _unitOfWork.BeginTransaction();
            _unitOfWork.OwnerRepository.Update(obj);
            _unitOfWork.Commit();

            return obj;
        }
    }
}
