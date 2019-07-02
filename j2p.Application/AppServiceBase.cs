using j2p.Application.Interfaces;
using j2p.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace j2p.Application
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public TEntity Add(TEntity obj)
        {
            _serviceBase.Add(obj);
            return obj;
        }

        public void Delete(TEntity obj)
        {
            _serviceBase.Delete(obj);
        }

        public TEntity Update(TEntity obj)
        {
            _serviceBase.Update(obj);
            return null;
        }

        public TEntity GetById(Guid id)
        {
            return _serviceBase.GetById(id);
        }

        public IList<TEntity> FindBy(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IList<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }
    }
}
