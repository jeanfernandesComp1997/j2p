﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace j2p.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        TEntity Add(TEntity obj);

        void Delete(TEntity obj);

        TEntity Update(TEntity obj);

        TEntity GetById(Guid id);

        IList<TEntity> FindBy(Expression<Func<TEntity, bool>> filter);

        IList<TEntity> GetAll();

        void Dispose();
    }
}
