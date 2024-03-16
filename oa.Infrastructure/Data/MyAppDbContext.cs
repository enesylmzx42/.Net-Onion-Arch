using Microsoft.EntityFrameworkCore;
using oa.Domain.Entities;

namespace oa.Infrastructure.Data
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
    }
}
