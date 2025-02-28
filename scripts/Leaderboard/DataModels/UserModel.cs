namespace Leaderboard;

public class UserModel : IDataModel<User>
{
    public string Id { get; set; }
    public string Name { get; set; }
    
    
    public User Map()
    {
        return new User
        {
            Id = Id, 
            Name = Name,
        };
    }
}