using Clothing_shop.Entities;
using Clothing_shop.VModel;
using OA.Domain.Common.Models;

namespace Clothing_shop.Repositories.IRepositories
{
    public interface IRoleRepo
    {
        Task<List<Role>> GetAll();
        Task<Role?> GetById(int id);
        Task Create(Role model);
        Task Update(Role model);
        Task Delete(Role model);
    }
}
