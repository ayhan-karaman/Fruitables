using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entities.Models.Common;

namespace Repositories.Contracts
{
    public interface IRepositoryBase<T>
    where T : class, new()
    {
        IQueryable<T> FindAll(bool tracking);
        T? FindCondition(Expression<Func<T, bool>> condition, bool tracking);
        void CreateEntity(T entity);
        void UpdateEntity(T entity);
        void DeleteEntity(T entity);
    }
}