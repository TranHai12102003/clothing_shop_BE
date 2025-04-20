using Clothing_shop.Entities;
using Clothing_shop.VModel;

namespace Clothing_shop.Repositories.IRepositories
{
    public interface IVoucherRepo
    {
        Task<List<Voucher>> GetAll(VoucherFilterParams parameters);
        Task<Voucher> GetById(int id);
        Task Create(Voucher model);
        Task Update(Voucher model);
        Task Delete(Voucher model);
    }
}
