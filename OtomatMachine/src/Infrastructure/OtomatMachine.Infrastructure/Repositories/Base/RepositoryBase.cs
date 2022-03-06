using Microsoft.EntityFrameworkCore;
using OtomatMachine.Domain.Entites.Base;
using OtomatMachine.Domain.Repositories.Base;
using OtomatMachine.Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OtomatMachine.Infrastructure.Repositories.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        private readonly OtomatMachineContext _otomatMachineContext;

        public RepositoryBase(OtomatMachineContext otomatMachineContext)
        {
            _otomatMachineContext = otomatMachineContext;
        }

        public async Task<List<T>> AddRangeAsync(List<T> entity)
        {
            await _otomatMachineContext.AddRangeAsync(entity);
            await _otomatMachineContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _otomatMachineContext.Set<T>().AddAsync(entity);
            await _otomatMachineContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _otomatMachineContext.Set<T>().Remove(entity);
            await _otomatMachineContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate = null)
        {
            return predicate == null
                ? await _otomatMachineContext.Set<T>().ToListAsync()
                : await _otomatMachineContext.Set<T>().Where(predicate: predicate).ToListAsync();
        }

        public async Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disableTracking = true)
        {
            IQueryable<T> query = _otomatMachineContext.Set<T>();
            if (disableTracking) query = query.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);
            if (predicate != null) query = query.Where(predicate);
            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _otomatMachineContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _otomatMachineContext.Entry(entity).State = EntityState.Modified;
            await _otomatMachineContext.SaveChangesAsync();
        }

      
    }
}
