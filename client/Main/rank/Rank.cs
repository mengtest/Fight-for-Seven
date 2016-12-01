using UnityEngine;
using System.Collections;

public enum RankType
{
    Competition,
    Wealth,
    Charm
}

public class Rank
{
    public int rank;
    public string account;
    public string username;
    public string description;
    public RankType type;
    
    public Rank(int rank, string account, string username, string description)
    {
        this.rank = rank;
        this.account = account;
        this.username = username;
        this.description = description;
    }
}
