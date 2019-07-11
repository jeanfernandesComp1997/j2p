using j2p.Domain.Entities;
using j2p.Domain.Interfaces.Repositories;
using NHibernate;

namespace j2p.Infra.Data.NHibernate.Repositories
{
    public class PlayerRepository : RepositoryBase<Player>, IPlayerRepository
    {
        private readonly ISession _session;

        public PlayerRepository(ISession session) : base(session)
        {
            _session = session;
        }
    }
}
