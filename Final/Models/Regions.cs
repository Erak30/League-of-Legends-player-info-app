using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Regions:I_Regions
{
    public string Region { get; set; }
    public string Shard { get; set; }
    public Regions(string _shard)
    {
        if(_shard=="EUW1"||_shard=="EUN1"|| _shard == "TR1"|| _shard == "RU")
        {
            Region = "europe";
        }if(_shard=="KR"|| _shard == "JP1")
        {
            Region = "asia";
        }if(_shard=="BR1"|| _shard == "NA1"|| _shard == "LA1" || _shard == "LA2")
        {
            Region = "americas";
        }
        Shard = _shard;
    }
}

