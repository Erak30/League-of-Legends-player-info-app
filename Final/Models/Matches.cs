using System;


public class Matches
{
    public string[] matchIDs { get; }
 
    public Matches(string MatchesString)
    {
        char[] SplitCharacters = { ',', '{', '}', ']', '[', '"' };
        var _MatchIDs = MatchesString.Split(SplitCharacters);
        matchIDs = _MatchIDs;
    }
}
