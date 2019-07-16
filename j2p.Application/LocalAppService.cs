using j2p.Application.Interfaces;
using j2p.Domain.Entities;
using j2p.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace j2p.Application
{
    public class LocalAppService : AppServiceBase<Local>, ILocalAppService
    {
        private readonly ILocalService _localService;

        public LocalAppService(ILocalService localService)
            : base(localService)
        {
            _localService = localService;
        }

        public Local Add(Local obj, Guid idOwner)
        {
            _localService.Add(obj, idOwner);
            return obj;
        }

        public void Delete(Guid id)
        {
            _localService.Delete(id);
        }

        public Local Update(Local obj)
        {
            _localService.Update(obj);
            return obj;
        }
    }
}
