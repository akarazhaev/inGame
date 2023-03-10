using inGame.Models;
using Microsoft.EntityFrameworkCore;

namespace inGame.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Basket> Baskets { get; set; } = null!;
        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
