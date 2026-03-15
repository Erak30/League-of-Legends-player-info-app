using System;

public class Champion
{
    public string name { get; }
    public string image { get; }
    public Champion(string _name)
    {
        name = _name;
        image = "https://ddragon.leagueoflegends.com/cdn/img/champion/splash/" + _name + "_0.jpg"; ;
    }
}
