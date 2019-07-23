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

        public Event Add(Event obj, Guid idOwner, Guid idLocal)
        {
            _eventService.Add(obj, idOwner, idLocal);
            return obj;
        }

        public void SubscribeEvent(Guid idEvent, Guid idPlayer)
        {
            _eventService.SubscribeEvent(idEvent, idPlayer);
        }

        public void UnsubscribeEvent(Guid idEvent, Guid idPlayer)
        {
            _eventService.UnsubscribeEvent(idEvent, idPlayer);
        }

        public void Delete(Guid id)
        {
            _eventService.Delete(id);
        }

        public Event Update(Event obj)
        {
            _eventService.Update(obj);
            return obj;
        }
    }
}
