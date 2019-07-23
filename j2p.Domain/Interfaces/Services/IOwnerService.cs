using j2p.Domain.Entities;
using System;

namespace j2p.Domain.Interfaces.Services
{
    public interface IOwnerService : IServiceBase<Owner>
    {
        Owner Save(Owner obj);

        void Delete(Guid id);

        Owner Update(Owner obj);
    }
}
