using Microsoft.EntityFrameworkCore;

namespace BookReservationApi.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Books> Books { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
