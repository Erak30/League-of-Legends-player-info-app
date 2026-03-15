using ApiData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class AsyncMethods:I_AsyncMethods
{
    private I_Regions region;
    public AsyncMethods(I_Regions _region) 
    {
        region = _region;
    }
    public async Task<string> request_matches(I_RiotID _Summoner) 
    {
        var HttpClient = new HttpClient();
        string request = "https://" + region.Region + ".api.riotgames.com/lol/match/v5/matches/by-puuid/" + _Summoner.puuid + "/ids?start=0&count=20" + "&api_key=" + Key.key;
        var response = await HttpClient.GetAsync(request);
        return await response.Content.ReadAsStringAsync();

    }
    public async Task<ApiData.Root> request_matchdata(Matches Matches)
    {
        var HttpClient = new HttpClient();
        var request = "https://" + region.Region + ".api.riotgames.com/lol/match/v5/matches/" + Matches.matchIDs[2] + "?api_key=" + Key.key;
        var response = await HttpClient.GetAsync(request);
        return await response.Content.ReadFromJsonAsync<ApiData.Root>();
    }
    public async Task<string> request_rank(I_RiotID Summoner)
    {
        var HttpClient = new HttpClient();
        string request = "https://" + region.Shard + ".api.riotgames.com/lol/league/v4/entries/by-summoner/" + Summoner.id + "?api_key=" + Key.key;
        var response = await HttpClient.GetAsync(request);
        return await response.Content.ReadAsStringAsync();
    }
    public async Task<string[]> request_item_name(string[] item_ID)
    {   
        var HttpClient = new HttpClient();
        string request = "https://ddragon.leagueoflegends.com/cdn/14.12.1/data/en_US/item.json";
        var response = await HttpClient.GetAsync(request);
        string text = await response.Content.ReadAsStringAsync();
        var jsonDoc = JsonDocument.Parse(text);
        string[] names = new string[7];
        int count = -1;
        var rootElement = jsonDoc.RootElement;
        foreach (var itemID in item_ID)
        {
            count++;
            foreach (var item in rootElement.EnumerateObject())
            {
                if (item.Value.ValueKind == JsonValueKind.Object)
                {
                    if (item.Name.Equals("data"))
                    {
                        foreach (var ID in item.Value.EnumerateObject())
                        {
                            if (ID.Name == itemID)
                            {
                                var thingy = ID.Value.GetProperty("name");
                                if (thingy.ValueKind == JsonValueKind.String)
                                {
                                    names[count] = thingy.GetString();
                                }
                            }
                        }
                        break;
                    }
                }
            }
        }
        return names;
    }
}
