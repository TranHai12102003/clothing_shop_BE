using System.Linq.Expressions;
using Clothing_shop.Context;
using Clothing_shop.Entities;
using Clothing_shop.Repositories.IRepositories;
using Clothing_shop.VModel;
using Microsoft.EntityFrameworkCore;

namespace Clothing_shop.Repositories
{
    public class VoucherRepo : IVoucherRepo
    {
        private readonly AppDbContext _context;
        public VoucherRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Voucher model)
        {
            _context.Vouchers.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Voucher model)
        {
            _context.Vouchers.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Voucher>> GetAll(VoucherFilterParams parameters)
        {
            return await _context.Vouchers.Where(BuildQueryable(parameters))
                .ToListAsync();
        }

        public async Task<Voucher> GetById(int id)
        {
            return await _context.Vouchers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Voucher model)
        {
            _context.Vouchers.Update(model);
            await _context.SaveChangesAsync();
        }
        private Expression<Func<Voucher, bool>> BuildQueryable(VoucherFilterParams fParams)
        {
            return x =>
                (fParams.VoucherCode == null || (x.VoucherCode != null && x.VoucherCode.Contains(fParams.VoucherCode))) &&
                (fParams.CreatedDate == null || (x.CreatedDate != null && x.CreatedDate.Year.Equals(fParams.CreatedDate.Value.Year) && x.CreatedDate.Month.Equals(fParams.CreatedDate.Value.Month) && x.CreatedDate.Day.Equals(fParams.CreatedDate.Value.Day))) &&
                (fParams.UpdatedDate == null || (x.UpdatedDate != null && x.UpdatedDate.Value.Year.Equals(fParams.UpdatedDate.Value.Year) && x.UpdatedDate.Value.Month.Equals(fParams.UpdatedDate.Value.Month) && x.UpdatedDate.Value.Day.Equals(fParams.UpdatedDate.Value.Day))) &&
                (fParams.IsActive == null || x.IsActive == fParams.IsActive);
        }
    }
}
