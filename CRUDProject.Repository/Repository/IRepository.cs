using CRUDProject.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRUDProject.Repository.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        public DbSet<T> Table { get; }
        Task<IList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetQueryable(Expression<Func<T,bool>> filter = null);

        Task<T> AddAsync(T entity);
        Task RemoveAsync(int id);
        Task<T> UpdateAsync(T entity);
        

    }
}
