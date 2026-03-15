using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface I_AsyncMethods
{
    public Task<string> request_matches(I_RiotID _Summoner);
    public Task<ApiData.Root> request_matchdata(Matches Matches);
    public Task<string> request_rank(I_RiotID Summoner);
    public Task<string[]> request_item_name(string[] item_ID);

}
