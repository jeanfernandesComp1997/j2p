using j2p.Domain.Entities;

namespace j2p.Domain.Interfaces.Repositories
{
    public interface IPlayerRepository : IUserRepository<Player>
    {
        Player Authentication(string email, string password);
    }
}
