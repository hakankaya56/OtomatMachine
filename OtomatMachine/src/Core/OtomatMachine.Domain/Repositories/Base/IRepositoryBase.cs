using OtomatMachine.Domain.Entites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtomatMachine.Domain.Repositories.Base
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate=null);
        Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disableTracking = true);
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<List<T>> AddRangeAsync(List<T> entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
