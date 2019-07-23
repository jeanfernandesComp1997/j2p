using j2p.Domain.Entities;
using j2p.Domain.Interfaces.Repositories;
using j2p.Domain.Interfaces.Services;
using System;

namespace j2p.Domain.Services
{
    public class EventService : ServiceBase<Event>, IEventService
    {
        private readonly IUoWRepository _unitOfWork;

        public EventService(IUoWRepository unitOfWork) : base(unitOfWork.EventRepository)
        {
            _unitOfWork = unitOfWork;
        }

        public Event Add(Event obj, Guid idOwner, Guid idLocal)
        {
            Player owner = _unitOfWork.PlayerRepository.GetById(idOwner);

            if (owner == null)
                throw new Exception("Owner não encontrado.");

            Local local = _unitOfWork.LocalRepository.GetById(idLocal);

            if (local == null)
                throw new Exception("Local não encontrado.");

            obj.Validate();

            obj.AddOwner(owner);
            obj.AddLocal(local);

            _unitOfWork.BeginTransaction();
            _unitOfWork.EventRepository.Add(obj);
            _unitOfWork.Commit();

            return obj;
        }

        public void SubscribeEvent(Guid idEvent, Guid idPlayer)
        {
            Event eventObj = _unitOfWork.EventRepository.GetById(idEvent);

            if (eventObj == null)
                throw new Exception("Evento não encontrado.");

            Player player = _unitOfWork.PlayerRepository.GetById(idPlayer);

            if (player == null)
                throw new Exception("Player não encontrado.");

            if (eventObj.Players.Count >= eventObj.LimitPlayers)
                throw new Exception("Não há mais vagas no evento.");

            eventObj.SubscribePlayer(player);

            _unitOfWork.BeginTransaction();
            _unitOfWork.EventRepository.Update(eventObj);
            _unitOfWork.Commit();
        }

        public void UnsubscribeEvent(Guid idEvent, Guid idPlayer)
        {
            Event eventObj = _unitOfWork.EventRepository.GetById(idEvent);

            if (eventObj == null)
                throw new Exception("Evento não encontrado.");

            Player player = _unitOfWork.PlayerRepository.GetById(idPlayer);

            if (player == null)
                throw new Exception("Player não encontrado.");

            if (eventObj.Players.Count >= eventObj.LimitPlayers)
                throw new Exception("Não há mais vagas no evento.");

            eventObj.UnsubscribeEvent(player);

            _unitOfWork.BeginTransaction();
            _unitOfWork.EventRepository.Update(eventObj);
            _unitOfWork.Commit();
        }

        public void Delete(Guid id)
        {
            Event eventObj = _unitOfWork.EventRepository.GetById(id);

            if (eventObj == null)
                throw new Exception("Evento não encontrado");

            _unitOfWork.BeginTransaction();
            _unitOfWork.EventRepository.Delete(eventObj);
            _unitOfWork.Commit();
        }

        public Event Update(Event obj)
        {
            obj.Validate();

            _unitOfWork.BeginTransaction();
            _unitOfWork.EventRepository.Update(obj);
            _unitOfWork.Commit();

            return obj;
        }
    }
}
