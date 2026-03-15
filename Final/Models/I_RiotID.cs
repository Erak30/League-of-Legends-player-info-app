using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface I_RiotID
{
    public string gameName { get; set; }
    public string tagLine { get; set; }
    public string puuid { get; set; }
    public string id { get; set; }
    public Task<bool> GetPlayerIDs(string _name_and_tag, I_Regions region);
}
