using j2p.Domain.Entities;
using System;

namespace j2p.Application.Interfaces
{
    public interface IPlayerAppService : IAppServiceBase<Player>
    {
        Player Add(Player obj);

        Player Authentication(string email, string password);

        void Delete(Guid id);

        Player Update(Player obj);
    }
}
