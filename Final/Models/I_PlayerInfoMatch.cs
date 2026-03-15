using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface I_PlayerInfoMatch
{
    public string ChampionName { get; set; }
    public Item Item0 { get; set; }
    public Item Item1 { get; set; }
    public Item Item2 { get; set; }
    public Item Item3 { get; set; }
    public Item Item4 { get; set; }
    public Item Item5 { get; set; }
    public Item Item6 { get; set; }
    public bool Win { get; set; }
    public Task<bool> GetMatchData(ApiData.Root root, I_RiotID Summoner, I_AsyncMethods AsyncInstance);
}
