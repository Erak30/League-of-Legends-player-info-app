using ApiData;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

public class PlayerInfoMatch:I_PlayerInfoMatch
{
	public string ChampionName { get; set; }
    public Item Item0 { get; set; }
    public Item Item1 { get; set; }
    public Item Item2 { get; set; }
    public Item Item3 { get; set; }
    public Item Item4 { get; set; }
    public Item Item5 { get; set; }
    public Item Item6 { get; set; }
    public bool Win {  get; set; }

    public async Task<bool> GetMatchData(ApiData.Root root, I_RiotID Summoner,I_AsyncMethods AsyncInstance)
    {
        foreach (Participant participant in root.Info.Participans)
        {
            if (participant.Puuid == Summoner.puuid)
            {
                ChampionName = participant.ChampionName;
                string[] Item_names = { participant.Item0.ToString(), participant.Item1.ToString(), participant.Item2.ToString(), participant.Item3.ToString(), participant.Item4.ToString(), participant.Item5.ToString(), participant.Item6.ToString() };
                string[] Items = await AsyncInstance.request_item_name(Item_names);
                Item0 = new Item(participant.Item0.ToString(), Items[0]);
                Item1 = new Item(participant.Item1.ToString(), Items[1]);
                Item2 = new Item(participant.Item2.ToString(), Items[2]);
                Item3 = new Item(participant.Item3.ToString(), Items[3]);
                Item4 = new Item(participant.Item4.ToString(), Items[4]);
                Item5 = new Item(participant.Item5.ToString(), Items[5]);
                Item6 = new Item(participant.Item6.ToString(), Items[6]);
                Win = participant.Win;
            }
        }
        return true;
    }
}
