using CRUDProject.Entities.DTOs;
using CRUDProject.Entities.Entities;
using CRUDProject.Repository.Repository;
using CRUDProject.Service.Services.Contract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRUDProject.Service.Services.Implements
{
    public class AppUserService : IAppUserService
    {
        private readonly IRepository<AppUser> _repository;

        public AppUserService(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public DbSet<AppUser> Table => _repository.Table;

        public async Task<AppUser> AddAsync(AppUser entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task<IList<AppUser>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<AppUser> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public IQueryable<AppUser> GetQueryable(Expression<Func<AppUser, bool>> filter = null)
        {
            return _repository.GetQueryable(filter);
        }

        public async Task RemoveAsync(int id)
        {
            await _repository.RemoveAsync(id);
        }

        public async Task<AppUser> UpdateAsync(AppUser entity)
        {
            return await _repository.UpdateAsync(entity);
        }
        public async Task<AppUser?> Login(UserLoginRequestModel model)
        {
            var user =await GetQueryable(x => x.Username == model.Username && x.Password == model.Password).FirstOrDefaultAsync();
            return user;
        }
    }
}
