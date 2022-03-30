using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoardSlotManager : MonoBehaviour
{
    [SerializeField] private TextMeshPro[] ScoreBoardSlots;
    [SerializeField] private TextMeshPro ScoreBoardTitle;

    private void Start()
    {
        DataSaverLoader.LoadData();

        ScoreBoardTitle.text = "Level " + DataSaverLoader.Gd.LatestLevel + " Scoreboard";

        for(int i = 0; i < ScoreBoardSlots.Length; i++)
        {
            ScoreBoardSlots[i].text += "            " + DataSaverLoader.Gd.Scoreboards[DataSaverLoader.Gd.LatestLevel - 1].Slots[i].PlayerName
                + "      " + DataSaverLoader.Gd.Scoreboards[DataSaverLoader.Gd.LatestLevel - 1].Slots[i].Score;
        }
    }


}
