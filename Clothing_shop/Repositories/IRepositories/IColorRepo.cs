using Clothing_shop.Entities;
using Clothing_shop.VModel;

namespace Clothing_shop.Repositories.IRepositories
{
    public interface IColorRepo
    {
        Task<List<Color>> GetAllAsync(ColorFilterParams parameters);
        Task<Color?> GetByIdAsync(int id);
        Task AddAsync(Color category);
        Task UpdateAsync(Color category);
        Task DeleteAsync(Color category);
    }
}
