using j2p.Domain.Entities;
using j2p.Domain.Interfaces.Repositories;
using j2p.Infra.Data.Context;

namespace j2p.Infra.Data.Repositories
{
    public class PlayerRepository : RepositoryBase<Player>, IPlayerRepository
    {
        private readonly j2pContext _context;

        public PlayerRepository(j2pContext context) : base(context)
        {
            _context = context;
        }

        public Player Add(Player obj)
        {
            _context.Set<Player>().Add(obj);
            _context.SaveChanges();

            return obj;
        }

        public void Delete(Player obj)
        {
            _context.Set<Player>().Remove(obj);
            _context.SaveChanges();
        }

        public Player Update(Player obj)
        {
            _context.Set<Player>().Update(obj);
            _context.SaveChanges();

            return obj;
        }
    }
}
