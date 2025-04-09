using Clothing_shop.Context;
using Clothing_shop.Entities;
using Clothing_shop.Mappings;
using Clothing_shop.Repositories.IRepositories;
using Clothing_shop.VModel;
using Microsoft.EntityFrameworkCore;
using OA.Domain.Common.Models;

namespace Clothing_shop.Repositories
{
    public class RoleRepo : IRoleRepo
    {
        private readonly AppDbContext _context;
        public RoleRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Role>> GetAll()
        {
            return await _context.Roles
                .ToListAsync();
        }
        public async Task<Role?> GetById(int id)
        {
            return await _context.Roles
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
        public async Task Create(Role model)
        {
            _context.Roles.AddAsync(model);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Role model)
        {
            _context.Roles.Update(model);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Role model)
        {
            _context.Roles.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}
