using Newtonsoft.Json;

namespace Leaderboard;

internal sealed class SessionCloseRequest
{
    [JsonProperty("userId")]
    public string UserId { get; set; }
}