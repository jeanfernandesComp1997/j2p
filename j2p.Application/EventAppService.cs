using j2p.Application.Interfaces;
using j2p.Domain.Entities;
using j2p.Domain.Interfaces.Services;
using System;

namespace j2p.Application
{
    public class EventAppService : AppServiceBase<Event>, IEventAppService
    {
        private readonly IEventService _eventService;

        public EventAppService(IEventService eventService)
            : base(eventService)
        {
            _eventService = eventService;
        }

        public Event Add(Event obj, Guid idOwner)
        {
            _eventService.Add(obj, idOwner);
            return obj;
        }

        public void Delete(Event obj)
        {
            _eventService.Delete(obj, obj.Id);
        }

        public Event Update(Event obj)
        {
            _eventService.Update(obj);
            return obj;
        }
    }
}
