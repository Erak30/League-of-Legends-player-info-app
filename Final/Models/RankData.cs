using System.Text.Json.Serialization;


public class RankData
{
    [JsonPropertyName("queueType")]
    public string QueueType { get; set; }
    [JsonPropertyName("tier")]
    public string Tier { get; set; }
    [JsonPropertyName("rank")]
    public string Rank { get; set; }
}

