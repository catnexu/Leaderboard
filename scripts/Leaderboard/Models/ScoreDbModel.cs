using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leaderboard;

public sealed class ScoreDbModel : IDbModel<ScoreModel>
{
    [Key, Column("id")]
    public string Id { get; set; }
        
    [Column("score")]
    public int Score { get; set; }

    public ScoreModel Map()
    {
        return new ScoreModel
        {
            Id = Id,
            Score = Score
        };
    }
}