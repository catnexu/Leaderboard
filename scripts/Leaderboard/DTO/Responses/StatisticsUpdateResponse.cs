using Newtonsoft.Json;

namespace Leaderboard;

public sealed class StatisticsUpdateResponse
{
    [JsonProperty("userId")]
    public string UserId { get; set; }
        
    [JsonProperty("score")]
    public int Score { get; set; }
}