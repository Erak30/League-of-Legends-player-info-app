using System.Diagnostics.Tracing;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

public class Rank:I_Icons
{
    public string QueueType;
    public string RankNumber;
    public string Tier;
    public string Image;
    public Rank(string jsondata)
    {
        RankData[] ranks = JsonSerializer.Deserialize<RankData[]>(jsondata);
        RankNumber = "UNRANKED";
        Tier = "UNRANKED";
        QueueType = "RANKED_SOLO_5x5";
        //RANKED_SOLO_5x5 AND RANKED_FLEX_SR

        foreach (RankData reference in ranks)
        {
            if (reference.QueueType == QueueType)
            {
                RankNumber = reference.Rank;
                Tier = reference.Tier;
            }
        }
        Image = "rank_" + Tier + ".png";
    }
    public string description()
    {
        if (QueueType == "RANKED_SOLO_5x5")
        {
            if (Tier == "UNRANKED" || Tier == "CHALLENGER" || Tier == "GRANDMASTER" || Tier == "MASTER")
            {
                return "Solo/Duo: " + Tier;
            }
            return "Solo/Duo: " + Tier + " " + RankNumber;
        }
        else 
        {
            if (Tier == "UNRANKED" || Tier == "CHALLENGER" || Tier == "GRANDMASTER" || Tier == "MASTER")
            {
                return "Flex: " + Tier;
            }
            return "Flex: " + Tier + " " + RankNumber;
        }
        
    }

}
