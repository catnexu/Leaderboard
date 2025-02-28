using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Leaderboard;

[DbContext(typeof(UserDbModel))]
public sealed class UserDbContext : DbContext
{
    public DbSet<UserDbModel> Users { get; set; }

    public UserDbContext(DbContextOptions<UserDbContext> options) :base(options)
    {
        
    }
}