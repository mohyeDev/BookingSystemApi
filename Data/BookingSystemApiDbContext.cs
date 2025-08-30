using BookingSystemApi.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookingSystemApi.Data
{
    public class BookingSystemApiDbContext : DbContext
    {

        public BookingSystemApiDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Roles> Roles { get; set; }
    }
}
