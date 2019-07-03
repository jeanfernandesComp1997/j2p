﻿using j2p.Domain.Entities;
using System;

namespace j2p.Domain.Interfaces.Services
{
    public interface IPlayerService : IServiceBase<Player>
    {
        Player Add(Player obj);

        void Delete(Player obj);

        Player Update(Player obj);
    }
}
