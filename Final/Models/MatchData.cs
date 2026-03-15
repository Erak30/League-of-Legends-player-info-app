using System.Text.Json.Serialization;

namespace ApiData
{
    public class Participant
    {
        [JsonPropertyName("ChampionName")]
        public string ChampionName { get; set; }
        [JsonPropertyName("puuid")]
        public string Puuid { get; set; }
        [JsonPropertyName("Item0")]
        public int Item0 { get; set; }
        [JsonPropertyName("Item1")]
        public int Item1 { get; set; }
        [JsonPropertyName("Item2")]
        public int Item2 { get; set; }
        [JsonPropertyName("Item3")]
        public int Item3 { get; set; }
        [JsonPropertyName("Item4")]
        public int Item4 { get; set; }
        [JsonPropertyName("Item5")]
        public int Item5 { get; set; }
        [JsonPropertyName("Item6")]
        public int Item6 { get; set; }
        [JsonPropertyName("Win")]
        public bool Win {  get; set; }
    }
    public class Information
    {
        [JsonPropertyName("gameMode")]
        public string GameMode { get; set; }

        [JsonPropertyName("participants")]
        public List<Participant> Participans { get; set; }
    }

    public class Root
    {   
        [JsonPropertyName("info")]
        public Information Info { get; set; }   
    }
}