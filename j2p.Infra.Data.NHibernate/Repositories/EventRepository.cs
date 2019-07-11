using j2p.Domain.Entities;
using j2p.Domain.Interfaces.Repositories;
using NHibernate;

namespace j2p.Infra.Data.NHibernate.Repositories
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        private readonly ISession _session;

        public EventRepository(ISession session) : base(session)
        {
            _session = session;
        }
    }
}
