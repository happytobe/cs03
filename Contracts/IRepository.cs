using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TC_CS03_API.Contracts
{
    /// <summary>
    /// Simple interface that all our database tables in implement.
    /// 
    /// It only holds the methods required for this Hackathon API and does not include UPDATE AND DELETE.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task<long> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(object id);
        Task<bool> ExistAsync(object id);
    }
}
