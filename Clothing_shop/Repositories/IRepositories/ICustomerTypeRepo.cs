using Clothing_shop.Entities;

namespace Clothing_shop.Repositories.IRepositories
{
    public interface ICustomerTypeRepo
    {
        Task<List<CustomerType>> GetAll();
        Task<CustomerType?> GetById(int id);
        Task Create(CustomerType customerType);
        Task Update(CustomerType customerType);
        Task Delete(CustomerType customerType);
    }
}
