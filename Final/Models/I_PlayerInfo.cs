using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface I_PlayerInfo
{
    public Task<bool> SetData(I_Regions Region, string GameNameandTag, I_RiotID Summoner, I_PlayerInfoMatch PlayerInfoFromMatch);

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
