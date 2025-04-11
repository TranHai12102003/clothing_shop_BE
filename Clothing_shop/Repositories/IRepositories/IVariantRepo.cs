using Clothing_shop.Entities;
using Clothing_shop.VModel;

namespace Clothing_shop.Repositories.IRepositories
{
    public interface IVariantRepo
    {
        Task<Variant?> GetById(int id);
        Task<List<Variant>> GetAll(VariantFilterParams parameters);
        Task Create(Variant entity);
        Task Update(Variant entity);
        Task Delete(Variant entity);
    }
}
