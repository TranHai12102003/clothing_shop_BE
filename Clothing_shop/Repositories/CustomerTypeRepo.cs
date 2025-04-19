using Clothing_shop.Context;
using Clothing_shop.Entities;
using Clothing_shop.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Clothing_shop.Repositories
{
    public class CustomerTypeRepo : ICustomerTypeRepo
    {
        private readonly AppDbContext _context;
        public CustomerTypeRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(CustomerType customerType)
        {
            _context.CustomerTypes.Add(customerType);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(CustomerType customerType)
        {
            _context.CustomerTypes.Remove(customerType);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CustomerType>> GetAll()
        {
            return await _context.CustomerTypes
                .ToListAsync();
        }

        public async Task<CustomerType?> GetById(int id)
        {
            return await _context.CustomerTypes
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Update(CustomerType customerType)
        {
            _context.CustomerTypes.Update(customerType);
            await _context.SaveChangesAsync();
        }
    }
}
