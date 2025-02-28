namespace Leaderboard;

public class UserDataModel : IDataModel<UserDbModel>
{
    public string Id { get; set; }
    public string Name { get; set; }
    
    
    public UserDbModel Map()
    {
        return new UserDbModel
        {
            Id = Id, 
            Name = Name,
        };
    }
}