using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.Concrete
{
    public class RepositoryBase<T> : IRepositoryBase<T>
    where T : class, new()
    {
        protected readonly RepositoryContext _context;

        public RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        public void CreateEntity(T entity) => _context.Set<T>().Add(entity);

        public void DeleteEntity(T entity)
        => _context.Set<T>().Remove(entity);

        public IQueryable<T> FindAll(bool tracking)
        => tracking ? _context.Set<T>() : _context.Set<T>().AsNoTracking();

        public T? FindCondition(Expression<Func<T, bool>> condition, bool tracking)
        => tracking ? _context.Set<T>().Where(condition).SingleOrDefault()
        : _context.Set<T>().Where(condition).AsNoTracking().SingleOrDefault();

        public void UpdateEntity(T entity)
        => _context.Set<T>().Update(entity);
    }
}