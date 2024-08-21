using Microsoft.EntityFrameworkCore;
using TicketService.model;
using TicketsService.Models;
namespace TicketService
{
    public class TicketsDbContext : DbContext
    {
        public TicketsDbContext(DbContextOptions<TicketsDbContext> options) : base(options)
        {
        }

         public DbSet<Ticket> Tickets { get; set; }
    
    }
}
