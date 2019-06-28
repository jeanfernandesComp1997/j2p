using j2p.Domain.Interfaces.Repositories;
using j2p.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
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

        public TEntity Add(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            _context.SaveChanges();

            return obj;
        }

        public void Delete(TEntity obj)
        {
            _context.Set<TEntity>().Remove(obj);
            _context.SaveChanges();
        }

        public TEntity Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();

            return obj;
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
