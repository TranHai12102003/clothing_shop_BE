using Clothing_shop.Context;
using Clothing_shop.Entities;
using Clothing_shop.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Clothing_shop.Repositories
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext _context;
        public CategoryRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories
                .Include(x => x.ParentCategory)
                .ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.Where(x=>x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
