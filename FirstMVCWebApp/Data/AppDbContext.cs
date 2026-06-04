using FirstMVCWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCWebApp.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)//Primary constructor
    {
        //public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}
        public DbSet<User> Users { get; set; }
    }
}
