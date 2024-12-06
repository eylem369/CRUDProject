using CRUDProject.Entities.DTOs;
using CRUDProject.Entities.Entities;
using CRUDProject.Repository.Repository;

namespace CRUDProject.Service.Services.Contract
{
    public interface IAppUserService : IRepository<AppUser>
    {
        Task<AppUser?> Login(UserLoginRequestModel model);
    }
}
