using Prueba_tecnica_net.Models;

namespace Prueba_tecnica_net.Repositories;

public interface IBalanceResponsiblePartyRepository
{
    Task<List<BalanceResponsibleParty>> GetAllAsync();
}
