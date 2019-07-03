using j2p.Application.Interfaces;
using j2p.Domain.Entities;
using j2p.Domain.Interfaces.Services;
using System;

namespace j2p.Application
{
    public class PlayerAppService : AppServiceBase<Player>, IPlayerAppService
    {
        private readonly IPlayerService _playerService;

        public PlayerAppService(IPlayerService playerService) 
            : base(playerService)
        {
            _playerService = playerService;
        }

        public Player Add(Player obj)
        {
            _playerService.Add(obj);
            return obj;
        }

        public void Delete(Player obj)
        {
            _playerService.Delete(obj);
        }

        public Player Update(Player obj)
        {
            _playerService.Update(obj);
            return obj;
        }
    }
}
