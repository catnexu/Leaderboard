using Newtonsoft.Json;

namespace Leaderboard.Helpers;

public static class ContentBodyHelper
{
    public static async Task<T?> Read<T>(HttpRequest request)
    {
        string value;
        using (StreamReader reader = new StreamReader(request.BodyReader.AsStream()))
        {
            value = await reader.ReadToEndAsync();
        }

        return JsonConvert.DeserializeObject<T>(value);
    }
}