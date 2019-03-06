using Microsoft.EntityFrameworkCore;

namespace MegaDesk.Models
{
    public class MegaDeskContext : DbContext
    {
        public MegaDeskContext(DbContextOptions<MegaDeskContext> options)
            : base(options)
        {
        }

        public DbSet<MegaDesk.Models.Quote> Quote { get; set; }
    }
}