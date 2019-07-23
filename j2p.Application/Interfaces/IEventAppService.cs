using j2p.Domain.Entities;
using System;

namespace j2p.Application.Interfaces
{
    public interface IEventAppService : IAppServiceBase<Event>
    {
        Event Add(Event obj, Guid idOwner, Guid idLocal);

        void SubscribeEvent(Guid idEvent, Guid idPlayer);

        void UnsubscribeEvent(Guid idEvent, Guid idPlayer);

        void Delete(Guid id);

        Event Update(Event obj);
    }
}
