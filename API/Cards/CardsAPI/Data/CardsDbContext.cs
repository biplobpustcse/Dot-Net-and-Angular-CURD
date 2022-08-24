using CardsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CardsAPI.Data
{
    public class CardsDbContext : DbContext
    {
        public CardsDbContext(DbContextOptions options) : base(options)
        {
        }
        //DbSet
        public DbSet<Card> Cards { get; set; }
    }
}
