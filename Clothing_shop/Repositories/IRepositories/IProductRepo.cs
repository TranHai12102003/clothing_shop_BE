using Clothing_shop.Entities;
using Clothing_shop.VModel;

namespace Clothing_shop.Repositories.IRepositories
{
    public interface IProductRepo
    {
        Task<List<Product>> GetAll(ProductFilterParams parameters);
        Task<Product> GetById(int id);
        Task<List<Product>> GetByCategoryId(ProductFilterParams parameters, int categoryId);
        Task Create(Product product);
        Task Update(Product product);
        Task Delete(Product product);
    }
}
