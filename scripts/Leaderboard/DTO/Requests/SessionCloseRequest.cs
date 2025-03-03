using Newtonsoft.Json;

namespace Leaderboard;

public sealed class SessionCloseRequest
{
    [JsonProperty("userId")]
    public string UserId { get; set; }
}