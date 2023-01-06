using DAW.DAL.Interfaces;
using DAW.Models;
using Microsoft.EntityFrameworkCore;

namespace DAW.DAL.Repositories
{
    public class DealRepository : IDealRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Deal> _deals;

        public DealRepository(DbContext context)
        {
            _context = context;
            _deals = context.Set<Deal>();
        }

        public async Task Add(Deal deal)
        {
            await _deals.AddAsync(deal);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<Deal>> GetAll()
        {
            return await _deals
                .Include(e => e.Project)
                .Include(e => e.Client)
                .ToListAsync();
        }

        public void Delete(Deal deal)
        {
            _deals.Remove(deal);
        }

        public async Task<Deal> FindById(int id)
        {
            return await _deals.FindAsync(id);
        }
    }
}
