using Newtonsoft.Json;

namespace Leaderboard;

public sealed class SessionStartRequest
{
    [JsonProperty("userId")]
    public string UserId { get; set; }
}