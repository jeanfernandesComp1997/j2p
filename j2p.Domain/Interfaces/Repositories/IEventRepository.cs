using j2p.Domain.Entities;

namespace j2p.Domain.Interfaces.Repositories
{
    public interface IEventRepository : IBaseRepository<Event>
    {
        Event Add(Event obj);

        void Delete(Event obj);

        Event Update(Event obj);
    }
}
