using j2p.Domain.Entities;
using j2p.Domain.Interfaces.Repositories;
using j2p.Infra.Data.Context;

namespace j2p.Infra.Data.Repositories
{
    public class PlayerRepository : RepositoryBase<Player>, IPlayerRepository
    {
        public PlayerRepository(j2pContext context) : base(context)
        {
        }
    }
}
