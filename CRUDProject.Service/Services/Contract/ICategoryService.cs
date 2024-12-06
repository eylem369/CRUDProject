using CRUDProject.Entities.Entities;
using CRUDProject.Repository.Repository;

namespace CRUDProject.Service.Services.Contract
{
    public interface ICategoryService : IRepository<Category>
    {
    }
}
