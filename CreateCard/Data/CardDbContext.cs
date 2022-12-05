using CreateCard.Models;
using Microsoft.EntityFrameworkCore;

namespace CreateCard.Data
{
    public class CardDbContext : DbContext
    {
        public CardDbContext(DbContextOptions<CardDbContext> options)
            : base(options)
        {

        }
        public DbSet<Card> Cards { get; set; }
    }
}
