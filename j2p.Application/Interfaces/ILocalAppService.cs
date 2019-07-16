using j2p.Domain.Entities;
using System;

namespace j2p.Application.Interfaces
{
    public interface ILocalAppService : IAppServiceBase<Local>
    {
        Local Add(Local obj, Guid idOwner);

        void Delete(Guid id);

        Local Update(Local obj);
    }
}
