using j2p.Domain.Interfaces.Repositories;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace j2p.Infra.Data.NHibernate.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ISession _session;

        public RepositoryBase(ISession session)
        {
            _session = session;
        }

        public TEntity Add(TEntity obj)
        {
             _session.Save(obj);

            return obj;
        }

        public TEntity Update(TEntity obj)
        {
            _session.Update(obj);

            return obj;
        }

        public void Delete(TEntity obj)
        {
            _session.Delete(obj);
        }

        public TEntity GetById(Guid id)
        {
            return _session.Get<TEntity>(id);
        }

        public IList<TEntity> FindBy(Expression<Func<TEntity, bool>> filter)
        {
            return _session.Query<TEntity>().Where(filter).ToList();
        }

        public IList<TEntity> GetAll()
        {
            return _session.Query<TEntity>().ToList();
        }

        public void Dispose()
        {
            _session.Dispose();
        }
    }
}
