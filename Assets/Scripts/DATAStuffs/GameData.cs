using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ScoreboardSlot
{
    public string PlayerName;
    public int Score;
}

[System.Serializable]
public struct Scoreboard
{
    public ScoreboardSlot[] Slots;
}

[System.Serializable]
public class GameData
{
    public Scoreboard[] Scoreboards;

    public int LatestScore;
    public int LatestLevel;
}