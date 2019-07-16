using j2p.Domain.Entities;
using j2p.Domain.Interfaces.Repositories;
using NHibernate;

namespace j2p.Infra.Data.NHibernate.Repositories
{
    public class LocalRepository : RepositoryBase<Local>, ILocalRepository
    {
        private readonly ISession _session;

        public LocalRepository(ISession session) : base(session)
        {
            _session = session;
        }
    }
}
