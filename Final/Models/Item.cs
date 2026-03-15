using System;

public class Item: I_Icons
{
    public string ItemID { get; }
    public string name { get; }
    public string image { get; }
    public string description()
    {
        return "Item: " + name;
    }
    public Item(string _itemID,string _name)
    {
        ItemID = _itemID;
        name = _name;
        image = "https://ddragon.leagueoflegends.com/cdn/14.12.1/img/item/" + ItemID + ".png";
    }
}
