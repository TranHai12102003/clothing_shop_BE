using System.Linq.Expressions;
using Clothing_shop.Context;
using Clothing_shop.Entities;
using Clothing_shop.Mappings;
using Clothing_shop.Repositories.IRepositories;
using Clothing_shop.VModel;
using Microsoft.EntityFrameworkCore;

namespace Clothing_shop.Repositories
{
    public class PromotionRepo : IPromotionRepo
    {
        private readonly AppDbContext _context;
        public PromotionRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Promotion>> GetAll(PromotionFilterParams parameters)
        {
              return await _context.Promotions
                .Where(BuildQueryable(parameters))
                .ToListAsync();
        }
        public async Task<Promotion> GetById(int id)
        {
            return await _context.Promotions
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task Create(Promotion model)
        {
            _context.Promotions.Add(model);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Promotion model)
        {
            _context.Attach(model);
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Promotion model)
        {
            _context.Promotions.Remove(model);
            await _context.SaveChangesAsync();
        }
        private Expression<Func<Promotion, bool>> BuildQueryable(PromotionFilterParams fParams)
        {
            return x => 
            (fParams.PromotionName == null || x.PromotionName.ToLower().Contains(fParams.PromotionName.ToLower())) &&
            (fParams.PercentDiscount == null || x.PercentDiscount == fParams.PercentDiscount) &&
            (fParams.DiscountValue == null || x.DiscountValue == fParams.DiscountValue) &&
            (fParams.StartDate == null || x.StartDate.Date == fParams.StartDate.Value.Date) &&
            (fParams.EndDate == null || x.EndDate.Date == fParams.EndDate.Value.Date) &&
            (fParams.IsActive == null || x.IsActive == fParams.IsActive);
        }
    }
}
