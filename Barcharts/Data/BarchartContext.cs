using Microsoft.EntityFrameworkCore;
using Barcharts.Models;

namespace Barcharts.Data
{
    public class BarchartContext : DbContext
    {
        public BarchartContext (DbContextOptions<BarchartContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}