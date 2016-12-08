using UnityEngine;
using System.Collections;

public class GameHallModel
{
    public int roomId;
    public int playerAHeaderIndex;
    public int playerBHeaderIndex;
    public string playerAName;
    public string playerBName;
    public bool isFull;

    public GameHallModel(int roomId, int aIndex,  string playerAName)
    {
        this.roomId = roomId;
        this.playerAHeaderIndex = aIndex;
        this.playerAName = playerAName;
        this.isFull = false;
    }

    public void PlayerEnter(int bIndex, string playerBName)
    {
        this.playerBHeaderIndex = bIndex;
        this.playerBName = playerBName;
        this.isFull = true;
    }
}
