using j2p.Domain.Entities;
using System;

namespace j2p.Domain.Interfaces.Services
{
    public interface IPlayerService : IServiceBase<Player>
    {
        Player Save(Player obj);

        Player Authentication(string email, string password);

        void Delete(Guid id);

        Player Update(Player obj);
    }
}
