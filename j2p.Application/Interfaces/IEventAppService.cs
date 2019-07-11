using j2p.Domain.Entities;
using System;

namespace j2p.Application.Interfaces
{
    public interface IEventAppService : IAppServiceBase<Event>
    {
        Event Add(Event obj);

        void Delete(Event obj);

        Event Update(Event obj);
    }
}
