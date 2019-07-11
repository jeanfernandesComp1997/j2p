using j2p.Domain.Interfaces.Repositories;
using j2p.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace j2p.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        private readonly j2pContext _context;

        public RepositoryBase(j2pContext context)
        {
            _context = context;
        }

        public TEntity GetById(Guid id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IList<TEntity> FindBy(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IList<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
