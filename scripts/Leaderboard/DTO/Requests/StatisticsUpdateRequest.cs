using Newtonsoft.Json;

namespace Leaderboard;

internal sealed class StatisticsUpdateRequest
{
    [JsonProperty("userId")]
    public string UserId { get; set; }
        
    [JsonProperty("scores")]
    public int Scores { get; set; }
}