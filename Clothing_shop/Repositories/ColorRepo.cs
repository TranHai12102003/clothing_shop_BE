using System.Linq.Expressions;
using Clothing_shop.Context;
using Clothing_shop.Entities;
using Clothing_shop.Repositories.IRepositories;
using Clothing_shop.VModel;
using Microsoft.EntityFrameworkCore;

namespace Clothing_shop.Repositories
{
    public class ColorRepo : IColorRepo
    {
        private readonly AppDbContext _context;
        public ColorRepo(AppDbContext context) {
            _context = context;
        }

        public async Task AddAsync(Color category)
        {
             _context.Colors.Add(category);
             await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Color category)
        {
            _context.Colors.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Color>> GetAllAsync(ColorFilterParams parameters)
        {
            return await _context.Colors
                .Where(BuildQueryable(parameters))
                .ToListAsync();
        }

        public Task<Color?> GetByIdAsync(int id)
        {
            return _context.Colors.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Color color)
        {
            _context.Colors.Update(color);
            await _context.SaveChangesAsync();
        }
        private Expression<Func<Color, bool>> BuildQueryable(ColorFilterParams fParams)
        {
            return x => (fParams.ColorName == null || x.ColorName.ToLower().Contains(fParams.ColorName.ToLower())
            && (fParams.ColorCode == null || x.ColorCode.ToLower().Contains(fParams.ColorCode.ToLower())));
        }
    }
}
