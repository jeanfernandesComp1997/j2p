using j2p.Domain.Entities;
using j2p.Domain.Interfaces.Repositories;
using NHibernate;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace j2p.Infra.Data.NHibernate.Repositories
{
    public class PlayerRepository : RepositoryBase<Player>, IPlayerRepository
    {
        private readonly ISession _session;

        public PlayerRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public Player Authentication(string email, string password)
        {
            return _session.Query<Player>().Where(x => x.Email == email && x.Password == password).FirstOrDefault();
        }
    }
}
