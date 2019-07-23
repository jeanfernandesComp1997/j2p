using j2p.Domain.Entities;
using System;

namespace j2p.Domain.Interfaces.Services
{
    public interface IEventService : IServiceBase<Event>
    {
        Event Add(Event obj, Guid idOwner, Guid idLocal);

        void SubscribeEvent(Guid idEvent, Guid idPlayer);

        void UnsubscribeEvent(Guid idEvent, Guid idPlayer);

        void Delete(Guid id);

        Event Update(Event obj);
    }
}
