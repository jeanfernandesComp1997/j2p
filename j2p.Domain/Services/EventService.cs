using j2p.Domain.Entities;
using j2p.Domain.Interfaces.Repositories;
using j2p.Domain.Interfaces.Services;
using System;

namespace j2p.Domain.Services
{
    public class EventService : ServiceBase<Event>, IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
            : base(eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public Event Add(Event obj)
        {
            obj.Validate();
            _eventRepository.Add(obj);
            return obj;
        }

        public void Delete(Event obj, Guid id)
        {
            obj.ChangeId(id);
            _eventRepository.Delete(obj);
        }

        public Event Update(Event obj)
        {
            obj.Validate();
            _eventRepository.Update(obj);
            return obj;
        }
    }
}
