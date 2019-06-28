using j2p.Domain.Entities;
using j2p.Domain.Interfaces.Repositories;
using j2p.Domain.Interfaces.Services;

namespace j2p.Domain.Services
{
    public class PlayerService : ServiceBase<Player>, IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository) 
            : base(playerRepository)
        {
            _playerRepository = playerRepository;
        }
    }
}
