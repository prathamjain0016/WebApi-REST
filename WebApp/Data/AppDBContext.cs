using Microsoft.EntityFrameworkCore;
using WebApp.Models;


namespace WebApp.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<MovieBooking> Bookings { get; set; }
        public AppDBContext(DbContextOptions<AppDBContext> options) 
            :base(options) 
        {

        }
    }
}
