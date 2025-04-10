using Clothing_shop.Entities;
using Clothing_shop.VModel;

namespace Clothing_shop.Repositories.IRepositories
{
    public interface ISizeRepo
    {
        Task<List<Size>> GetAll(SizeFilterParams parameters);
        Task<Size?> GetById(int id);
        Task Create(Size size);
        Task Update(Size size);
        Task Delete(Size size);
    }
}
