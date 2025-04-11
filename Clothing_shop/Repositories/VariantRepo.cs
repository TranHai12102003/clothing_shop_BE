using System.Linq.Expressions;
using Clothing_shop.Context;
using Clothing_shop.Entities;
using Clothing_shop.Repositories.IRepositories;
using Clothing_shop.VModel;
using Microsoft.EntityFrameworkCore;

namespace Clothing_shop.Repositories
{
    public class VariantRepo : IVariantRepo
    {
        private readonly AppDbContext _context;
        public VariantRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Variant?> GetById(int id)
        {
            return await _context.Variants
                .Include(v => v.Product)
                .Include(v => v.Size)
                .Include(v => v.Color)
                .FirstOrDefaultAsync(v => v.Id == id);
        }
        public async Task<List<Variant>> GetAll(VariantFilterParams parameters)
        {
            return await _context.Variants
                .Where(BuildQueryable(parameters))
                .Include(v => v.Product)
                .Include(v => v.Size)
                .Include(v => v.Color)
                .ToListAsync();
        }
        public async Task Create(Variant entity)
        {
             _context.Variants.Add(entity);
             await _context.SaveChangesAsync();
        }
        public  async Task Update(Variant entity)
        {
            _context.Variants.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Variant entity)
        {
            _context.Variants.Remove(entity);
            await _context.SaveChangesAsync();
        }
        private Expression<Func<Variant, bool>> BuildQueryable(VariantFilterParams fParams)
        {
            return x => 
            (fParams.ProductId == null || x.ProductId != null && x.ProductId == fParams.ProductId) &&
            (fParams.SizeId == null || x.SizeId != null && x.SizeId == fParams.SizeId) &&
            (fParams.ColorId == null || x.ColorId !=null && x.ColorId == fParams.ColorId);
        }
    }
}
