using j2p.Domain.Entities;
using System;

namespace j2p.Domain.Interfaces.Services
{
    public interface ILocalService : IServiceBase<Local>
    {
        Local Add(Local obj, Guid idOwner);

        void Delete(Guid id);

        Local Update(Local obj);
    }
}
