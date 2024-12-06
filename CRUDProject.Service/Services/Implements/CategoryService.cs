using CRUDProject.Entities.Entities;
using CRUDProject.Repository.Repository;
using CRUDProject.Service.Services.Contract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRUDProject.Service.Services.Implements
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _repository;

        public CategoryService(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public DbSet<Category> Table => _repository.Table;

        public async Task<Category> AddAsync(Category entity)
        {
           return await _repository.AddAsync(entity);
        }

        public async Task<IList<Category>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public IQueryable<Category> GetQueryable(Expression<Func<Category, bool>> filter = null)
        {
            return _repository.GetQueryable(filter);
        }

        public async Task RemoveAsync(int id)
        {
            await _repository.RemoveAsync(id);
        }

        public async Task<Category> UpdateAsync(Category entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}
