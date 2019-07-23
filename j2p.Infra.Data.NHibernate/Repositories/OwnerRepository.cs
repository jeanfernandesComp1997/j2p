using j2p.Domain.Entities;
using j2p.Domain.Interfaces.Repositories;
using NHibernate;

namespace j2p.Infra.Data.NHibernate.Repositories
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        private readonly ISession _session;

        public OwnerRepository(ISession session) : base(session)
        {
            _session = session;
        }
    }
}
