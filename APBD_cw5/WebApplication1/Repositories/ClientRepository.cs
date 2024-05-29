using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly MyDbContext _context;

    public ClientRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task DeleteClientAsync(int idClient)
    {
        if (await _context.ClientTrips.AnyAsync(record => record.IdClient == idClient))
            throw new Exception("Client has at least one trip!");
        Client? clientToRemove =
            await _context.Clients.Where(record => record.IdClient == idClient).FirstOrDefaultAsync();
        if (clientToRemove == null)
            throw new Exception("There is no such client");
        _context.Remove(clientToRemove);
    }
}