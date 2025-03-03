using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leaderboard;

public sealed class UserDbModel : IDbModel<UserModel>
{
    [Key, Column("id")]
    public string Id { get; set; }
    
    [Column("name")]
    public string Name { get; set; }

    public UserModel Map()
    {
        return new UserModel
        {
            Id = Id,
            Name = Name,
        };
    }
}