using j2p.Domain.Entities;
using System;

namespace j2p.Application.Interfaces
{
    public interface IPlayerAppService : IAppServiceBase<Player>
    {
        Player Add(Player obj);

        void Delete(Player obj, Guid id);

        Player Update(Player obj);
    }
}
