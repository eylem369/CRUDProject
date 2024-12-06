using CRUDProject.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRUDProject.Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<T> AddAsync(T entity)
        {
            await Table.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }

        public IQueryable<T> GetQueryable(Expression<Func<T, bool>> filter = null)
        {
            return  filter is not null
                    ? Table.Where(filter)
                    : Table.AsQueryable();
        }


        public async Task<T> GetByIdAsync(int id)
        {
            return await Table.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            T entity =  await GetByIdAsync(id);
            Table.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            Table.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
