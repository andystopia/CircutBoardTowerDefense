using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadInAtStart : MonoBehaviour
{
    private void Awake()
    {
        if (!DataSaverLoader.LoadData())
        {
            DataSaverLoader.NewData();
        }
        DataSaverLoader.SortData(false, 1);


        //Debug.Log("Level: " + 1 + " PlayerNamew: " + DataSaverLoader.Gd.Scoreboards[0].Slots[0].PlayerName + "Score: " + DataSaverLoader.Gd.Scoreboards[0].Slots[0].Score);
        for (int i = 0; i < DataSaverLoader.Gd.Scoreboards[0].Slots.Length; i++)
        {
            Debug.Log("                                              #" + (i + 1) + " Ranked -> PlayerName: " + DataSaverLoader.Gd.Scoreboards[0].Slots[i].PlayerName + "    Score: " + DataSaverLoader.Gd.Scoreboards[0].Slots[i].Score);
        }


    }
}
