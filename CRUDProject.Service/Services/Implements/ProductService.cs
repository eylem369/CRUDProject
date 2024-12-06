using CRUDProject.Entities.Entities;
using CRUDProject.Repository.Repository;
using CRUDProject.Service.Services.Contract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRUDProject.Service.Services.Implements
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public DbSet<Product> Table => _repository.Table;

        public async Task<Product> AddAsync(Product entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task<IList<Product>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public IQueryable<Product> GetQueryable(Expression<Func<Product, bool>> filter = null)
        {
            return _repository.GetQueryable(filter);
        }
        public async Task<Product> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(int id)
        {
            await _repository.RemoveAsync(id);
        }

        public async Task<Product> UpdateAsync(Product entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}
