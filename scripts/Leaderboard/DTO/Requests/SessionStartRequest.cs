using Newtonsoft.Json;

namespace Leaderboard;

internal sealed class SessionStartRequest
{
    [JsonProperty("userId")]
    public string UserId { get; set; }
}