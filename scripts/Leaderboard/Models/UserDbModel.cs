using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leaderboard;

public sealed class UserDbModel : IDbModel<UserDataModel>
{
    [Key, Column("id")]
    public string Id { get; set; }
    
    [Column("name")]
    public string Name { get; set; }

    public UserDataModel Map()
    {
        return new UserDataModel
        {
            Id = Id,
            Name = Name,
        };
    }
}