
using Microsoft.EntityFrameworkCore;
using TShirtAppAPI.Models;


namespace ContosoPets.Api.Data
{
    public class ContosoPetsContext : DbContext
    {
        public ContosoPetsContext(DbContextOptions<ContosoPetsContext> options)
            : base(options)
        {
        }

        public DbSet<TShirtOrder> TShirtOrders { get; set; }
    }
}