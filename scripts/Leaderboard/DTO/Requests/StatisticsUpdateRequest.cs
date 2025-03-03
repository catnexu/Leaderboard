using Newtonsoft.Json;

namespace Leaderboard;

public sealed class StatisticsUpdateRequest
{
    [JsonProperty("userId")]
    public string UserId { get; set; }
        
    [JsonProperty("scores")]
    public int Scores { get; set; }
}