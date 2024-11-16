using Microsoft.EntityFrameworkCore;
using Prueba_tecnica_net.Data;
using Prueba_tecnica_net.Models;

namespace Prueba_tecnica_net.Repositories;

public class BalanceResponsiblePartyRepository : IBalanceResponsiblePartyRepository
{
    private readonly ApplicationDbContext _context;

    public BalanceResponsiblePartyRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<BalanceResponsibleParty>> GetAllAsync()
    {
        return await _context.BalanceResponsibleParties.ToListAsync();
    }
}
