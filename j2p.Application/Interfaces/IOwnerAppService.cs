using j2p.Domain.Entities;
using System;

namespace j2p.Application.Interfaces
{
    public interface IOwnerAppService : IAppServiceBase<Owner>
    {
        Owner Add(Owner obj);

        void Delete(Guid id);

        Owner Update(Owner obj);
    }
}
