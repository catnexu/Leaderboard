using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Leaderboard;

[DbContext(typeof(UserDbModel))]
public sealed class UserDbContext : DbContext
{
    public DbSet<UserDbModel> Users { get; set; }

    public UserDbContext(DbContextOptions<UserDbContext> options) :base(options)
    {
        
    }
    
    
    public async Task<UserModel?> UpdateUserInfo(string id, string name)
    {
        if (string.IsNullOrEmpty(id))
        {
            Logger.Log("Cannot add user info with null or empty id");
            return null;
        }

        UserDbModel? entity = await Users.FindAsync(id);
        if (entity == null)
        {
            EntityEntry<UserDbModel> addedEntity = await Users.AddAsync(new UserDbModel
            {
                Id = id, 
                Name = name, 
            });

            await SaveChangesAsync();
            return addedEntity.Entity.Map();
        }

        Users.Entry(entity).State = EntityState.Detached;
        EntityEntry<UserDbModel> entry = Users.Update(new UserDbModel
        {
            Id = id, 
            Name = name, 
        });

        entry.State = EntityState.Modified;
        UserDbModel updatedEntity = entry.Entity;

        await SaveChangesAsync();

        return updatedEntity.Map();
    }
}