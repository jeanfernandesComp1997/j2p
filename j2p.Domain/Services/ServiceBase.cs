﻿using j2p.Domain.Interfaces.Repositories;
using j2p.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace j2p.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository;

        public ServiceBase(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public TEntity Add(TEntity obj)
        {
            _repository.Add(obj);
            return obj;
        }

        public void Delete(TEntity obj)
        {
            _repository.Delete(obj);
        }

        public TEntity Update(TEntity obj)
        {
            _repository.Update(obj);
            return obj;
        }

        public TEntity GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public IList<TEntity> FindBy(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IList<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}