using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace j2p.Application.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        TEntity GetById(Guid id);

        IList<TEntity> FindBy(Expression<Func<TEntity, bool>> filter);

        IList<TEntity> GetAll();

        void Dispose();
    }
}
