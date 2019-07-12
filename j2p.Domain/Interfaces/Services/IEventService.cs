using j2p.Domain.Entities;
using System;

namespace j2p.Domain.Interfaces.Services
{
    public interface IEventService : IServiceBase<Event>
    {
        Event Add(Event obj, Guid idOwner);

        void Delete(Event obj, Guid id);

        Event Update(Event obj);
    }
}
