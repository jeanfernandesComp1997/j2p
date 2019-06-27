using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace j2p.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        TEntity Add(TEntity obj);

        TEntity Update(TEntity obj);

        void Delete(TEntity obj);

        IList<TEntity> GetAll();

        TEntity GetById(Guid id);

        IList<TEntity> FindBy(Expression<Func<TEntity, bool>> filter);
    }
}
