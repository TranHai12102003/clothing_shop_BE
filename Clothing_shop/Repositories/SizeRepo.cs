using System.Linq.Expressions;
using Clothing_shop.Context;
using Clothing_shop.Entities;
using Clothing_shop.Repositories.IRepositories;
using Clothing_shop.VModel;
using Microsoft.EntityFrameworkCore;

namespace Clothing_shop.Repositories
{
    public class SizeRepo : ISizeRepo
    {
        private readonly AppDbContext _context;
        public SizeRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Size>> GetAll(SizeFilterParams parameters)
        {
            return await _context.Sizes
                .Where(BuildQueryable(parameters))
                .ToListAsync();
        }
        public async Task<Size?> GetById(int id)
        {
            return await _context.Sizes.FindAsync(id);
        }
        public async Task Create(Size size)
        {
            await _context.Sizes.AddAsync(size);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Size size)
        {
            _context.Sizes.Update(size);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Size size)
        {
            _context.Sizes.Remove(size);
            await _context.SaveChangesAsync();
        }
        private Expression<Func<Size, bool>> BuildQueryable(SizeFilterParams fParams)
        {
            return x => (fParams.SizeName == null || x.SizeName.ToLower().Contains(fParams.SizeName.ToLower()) &&
            (fParams.CreatedDate == null || (x.CreatedDate != null && x.CreatedDate.Year.Equals(fParams.CreatedDate.Value.Year) && x.CreatedDate.Month.Equals(fParams.CreatedDate.Value.Month) && x.CreatedDate.Day.Equals(fParams.CreatedDate.Value.Day))) &&
            (fParams.UpdatedDate == null || (x.UpdatedDate != null && x.UpdatedDate.Value.Year.Equals(fParams.UpdatedDate.Value.Year) && x.UpdatedDate.Value.Month.Equals(fParams.UpdatedDate.Value.Month) && x.UpdatedDate.Value.Day.Equals(fParams.UpdatedDate.Value.Day))));
        }
    }
}
