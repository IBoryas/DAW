using DAW.DAL.Interfaces;
using DAW.Models;
using Microsoft.EntityFrameworkCore;

namespace DAW.DAL.Repositories
{
    public class ClientRepository: IClientRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Client> _clients;

        public ClientRepository(DbContext context)
        {
            _context = context;
            _clients = context.Set<Client>();
        }

        public async Task Add(Client client)
        {
            await _clients.AddAsync(client);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<Client>> GetAll()
        {
            return await _clients
                .Include(e=>e.Deals)
                .ToListAsync();
        }

        public void Delete(Client client)
        {
            _clients.Remove(client);
        }

        public async Task<Client> FindById(int id)
        {
            return await _clients.FindAsync(id);
        }
    }
}
