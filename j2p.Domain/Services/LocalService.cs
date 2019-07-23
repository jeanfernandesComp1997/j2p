using j2p.Domain.Entities;
using j2p.Domain.Interfaces.Repositories;
using j2p.Domain.Interfaces.Services;
using System;

namespace j2p.Domain.Services
{
    public class LocalService : ServiceBase<Local>, ILocalService
    {
        private readonly IUoWRepository _unitOfWork;

        public LocalService(IUoWRepository unitOfWork) : base(unitOfWork.LocalRepository)
        {
            _unitOfWork = unitOfWork;
        }

        public Local Add(Local obj, Guid idOwner)
        {
            Owner owner = _unitOfWork.OwnerRepository.GetById(idOwner);

            if (owner == null)
                throw new Exception("Owner não encontrado.");

            obj.Validate();

            obj.AddOwner(owner);

            _unitOfWork.BeginTransaction();
            _unitOfWork.LocalRepository.Add(obj);
            _unitOfWork.Commit();

            return obj;
        }

        public void Delete(Guid id)
        {
            Local local = _unitOfWork.LocalRepository.GetById(id);

            if (local == null)
                throw new Exception("Local não encontrado");

            _unitOfWork.BeginTransaction();
            _unitOfWork.LocalRepository.Delete(local);
            _unitOfWork.Commit();
        }

        public Local Update(Local obj)
        {
            obj.Validate();

            _unitOfWork.BeginTransaction();
            _unitOfWork.LocalRepository.Update(obj);
            _unitOfWork.Commit();

            return obj;
        }
    }
}
