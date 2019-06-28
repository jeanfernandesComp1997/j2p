using j2p.Application.Interfaces;
using j2p.Domain.Entities;
using j2p.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
