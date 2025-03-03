namespace Leaderboard;

public sealed class ScoreModel : IDataModel<ScoreDbModel>
{
    public string Id { get; set; }
    public int Score { get; set; }
        
    public ScoreDbModel Map()
    {
        return new ScoreDbModel
        {
            Id = Id, 
            Score = Score, 
        };
    }
}