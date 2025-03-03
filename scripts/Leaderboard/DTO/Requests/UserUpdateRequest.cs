using Newtonsoft.Json;

namespace Leaderboard;

public sealed class UserUpdateRequest
{
    [JsonProperty("userId")]
    public string UserId { get; set; }
    
    [JsonProperty("name")]
    public string Nickname { get; set; }
}