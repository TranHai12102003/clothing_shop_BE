using System.Linq.Expressions;
using Clothing_shop.Context;
using Clothing_shop.Entities;
using Clothing_shop.Repositories.IRepositories;
using Clothing_shop.VModel;
using Microsoft.EntityFrameworkCore;

namespace Clothing_shop.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext _context;
        public ProductRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAll(ProductFilterParams parameters)
        {
            return await _context.Products
                .Where(BuildQueryable(parameters))
                .Include(x=>x.Category)
                .ToListAsync();
        }

        public async Task<List<Product>> GetByCategoryId(ProductFilterParams parameters, int categoryId)
        {
            return await _context.Products
                .Where(x => x.CategoryId == categoryId)
                .Where(BuildQueryable(parameters))
                .Include(x => x.Category)
                .ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
        private Expression<Func<Product, bool>> BuildQueryable(ProductFilterParams fParams)
        {
            return x => (fParams.Name == null || x.ProductName.ToLower().Contains(fParams.Name.ToLower()));
        }
    }
}
