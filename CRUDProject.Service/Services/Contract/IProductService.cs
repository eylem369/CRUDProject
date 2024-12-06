using CRUDProject.Entities.Entities;
using CRUDProject.Repository.Repository;

namespace CRUDProject.Service.Services.Contract
{
    public interface IProductService : IRepository<Product>
    {
    }
}
