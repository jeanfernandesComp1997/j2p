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

        public Player Add(Player obj)
        {
            obj.Validate();
            _playerRepository.Add(obj);
            return obj;
        }

        public void Delete(Player obj)
        {
            _playerRepository.Delete(obj);
        }

        public Player Update(Player obj)
        {
            obj.Validate();
            _playerRepository.Update(obj);
            return obj;
        }
    }
}
