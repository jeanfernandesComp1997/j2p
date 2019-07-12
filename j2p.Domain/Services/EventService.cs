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

        public Event Add(Event obj, Guid idOwner)
        {
            Player owner = _unitOfWork.PlayerRepository.GetById(idOwner);

            if (owner == null)
                throw new Exception("Owner não encontrado.");
            
            obj.Validate();

            obj.AddOwner(owner);

            _unitOfWork.BeginTransaction();
            _unitOfWork.EventRepository.Add(obj);
            _unitOfWork.Commit();

            return obj;
        }

        public void Delete(Event obj, Guid id)
        {
            //_eventRepository.Delete(obj);
        }

        public Event Update(Event obj)
        {
            /*obj.Validate();
            _eventRepository.Update(obj);
            return obj;*/

            return null;
        }
    }
}
