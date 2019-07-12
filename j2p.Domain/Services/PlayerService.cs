using j2p.Domain.Entities;
using j2p.Domain.Interfaces.Repositories;
using j2p.Domain.Interfaces.Services;
using System;

namespace j2p.Domain.Services
{
    public class PlayerService : ServiceBase<Player>, IPlayerService
    {
        private readonly IUoWRepository _unitOfWork;

        public PlayerService(IUoWRepository unitOfWork) : base(unitOfWork.PlayerRepository)
        {
            _unitOfWork = unitOfWork;
        }

        public Player Save(Player obj)
        {
            obj.Validate();

            _unitOfWork.BeginTransaction();
            _unitOfWork.PlayerRepository.Add(obj);
            _unitOfWork.Commit();

            return obj;
        }

        public void Delete(Guid id)
        {
            Player player = _unitOfWork.PlayerRepository.GetById(id);

            if (player == null)
                throw new Exception("Player não encontrado");

            _unitOfWork.BeginTransaction();
            _unitOfWork.PlayerRepository.Delete(player);
            _unitOfWork.Commit();
        }

        public Player Update(Player obj)
        {
            obj.Validate();

            _unitOfWork.BeginTransaction();
            _unitOfWork.PlayerRepository.Update(obj);
            _unitOfWork.Commit();

            return obj;
        }
    }
}
