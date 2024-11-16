using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Prueba_tecnica_net.Models;

namespace Prueba_tecnica_net.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<BalanceResponsibleParty> BalanceResponsibleParties { get; set; }
}
