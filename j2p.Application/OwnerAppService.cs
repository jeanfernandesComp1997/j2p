using j2p.Application.Interfaces;
using j2p.Domain.Entities;
using j2p.Domain.Interfaces.Services;
using System;

namespace j2p.Application
{
    public class OwnerAppService : AppServiceBase<Owner>, IOwnerAppService
    {
        private readonly IOwnerService _ownerService;

        public OwnerAppService(IOwnerService ownerService)
            : base(ownerService)
        {
            _ownerService = ownerService;
        }

        public Owner Add(Owner obj)
        {
            _ownerService.Save(obj);
            return obj;
        }

        public void Delete(Guid id)
        {
            _ownerService.Delete(id);
        }

        public Owner Update(Owner obj)
        {
            _ownerService.Update(obj);
            return obj;
        }
    }
}
