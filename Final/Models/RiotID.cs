using ApiData;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

public class RiotID:I_RiotID
{
    public string gameName { get; set; }
    public string tagLine { get; set; }
    public string puuid { get; set; }
    public string id { get; set; }
    public async Task<bool> GetPlayerIDs(string _name_and_tag,I_Regions region)
    {
        string[] seperated_name_tag=_name_and_tag.Split('#');
        string _name = seperated_name_tag[0];
        string _tagline= seperated_name_tag[1];
        var HttpClient = new HttpClient();
        string request = "https://" + region.Region + ".api.riotgames.com/riot/account/v1/accounts/by-riot-id/" + _name + "/" + _tagline + "?api_key=" + Key.key;
        var response = await HttpClient.GetAsync(request);
        string text = await response.Content.ReadAsStringAsync();
        var json = JsonDocument.Parse(text);
        string _puuid;
        _puuid = json.RootElement.GetProperty("puuid").GetString();
        request = "https://" + region.Shard + ".api.riotgames.com/lol/summoner/v4/summoners/by-puuid/" + _puuid + "?api_key=" + Key.key;
        response = await HttpClient.GetAsync(request);
        text = await response.Content.ReadAsStringAsync();
        json = JsonDocument.Parse(text);
        string _id;
        _id = json.RootElement.GetProperty("id").GetString();
        gameName = _name;
        tagLine = _tagline;
        puuid = _puuid;
        id = _id;
        return true;
    }
}