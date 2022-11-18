using Microsoft.EntityFrameworkCore;
using TicketModule.Data.Entities;

namespace TicketModule.Data;

class TicketContext : DbContext
{
    public TicketContext(DbContextOptions<TicketContext> option) : base(option)
    {

    }

    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<TicketMessage> TicketMessages { get; set; }
}