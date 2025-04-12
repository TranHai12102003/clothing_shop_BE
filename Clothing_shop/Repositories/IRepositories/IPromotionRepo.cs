using Clothing_shop.Entities;
using Clothing_shop.VModel;

namespace Clothing_shop.Repositories.IRepositories
{
    public interface IPromotionRepo
    {
        Task<List<Promotion>> GetAll(PromotionFilterParams parameters);
        Task<Promotion> GetById(int id);
        Task Create(Promotion model);
        Task Update(Promotion model);
        Task Delete(Promotion model);
    }
}
