using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class PlayerInfo:I_PlayerInfo
{
    public bool Error { get; set; }
    public string ChampionName { get; set; }
    public string ErrorMessage { get; set; }
    public Champion Champion { get; set; }
    public Rank RankPlayer { get; set; }
    public Item Item0 { get; set; }
    public Item Item1 { get; set; }
    public Item Item2 { get; set; }
    public Item Item3 { get; set; }
    public Item Item4 { get; set; }
    public Item Item5 { get; set; }
    public Item Item6 { get; set; }
    public bool Win { get; set; }
    public async Task<bool> SetData(I_Regions Region,string GameNameandTag,I_RiotID Summoner, I_PlayerInfoMatch PlayerInfoFromMatch)
    {
        Error = false;
        bool Valid_Puuid = true;
        ApiData.Root matches;
        try
        {
            await Summoner.GetPlayerIDs(GameNameandTag, Region);
        }
        catch
        {
            Error = true;
            Valid_Puuid = false;
            ErrorMessage = "Sorry, no player with this name and tag found in this region!";
        }
        if (Valid_Puuid == true)
        {
            I_AsyncMethods AsyncInstance = new AsyncMethods(Region);
            var MatchTask = AsyncInstance.request_matches(Summoner);
            var RankTask = AsyncInstance.request_rank(Summoner);
            await MatchTask;
            Matches Matches = new Matches(MatchTask.Result);
            var MatchDataTask = AsyncInstance.request_matchdata(Matches);
            await RankTask;
            var PlayerRank = new Rank(RankTask.Result);
            try
            {
                await MatchDataTask;
                await PlayerInfoFromMatch.GetMatchData(MatchDataTask.Result, Summoner, AsyncInstance);
            }
            catch
            {
                Error = true;
                ErrorMessage = "Sorry,no matches found for this player!";
            }
            if (Error==false) 
            {
                ErrorMessage = "";
                RankPlayer = PlayerRank;
                ChampionName = PlayerInfoFromMatch.ChampionName;
                Champion = new Champion(ChampionName);
                Item0 = PlayerInfoFromMatch.Item0;
                Item1 = PlayerInfoFromMatch.Item1;
                Item2 = PlayerInfoFromMatch.Item2;
                Item3 = PlayerInfoFromMatch.Item3;
                Item4 = PlayerInfoFromMatch.Item4;
                Item5 = PlayerInfoFromMatch.Item5;
                Item6 = PlayerInfoFromMatch.Item6;
                Win = PlayerInfoFromMatch.Win;
            }
        }
        return Error;
    }
    public string WinText()
    {
        if (Win == true)
        {
            return "VICTORY";
        }
        else
        {
            return "DEFEAT";
        }
    }
    public Color WinColor()
    {
        if (Win == true)
        {
            return Color.FromHex("#0acbe6");
        }
        else
        {
            return Color.FromHex("#fc2344");
        }
    }
}
