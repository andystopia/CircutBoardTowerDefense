using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadInAtStart : MonoBehaviour
{
    private void Awake()
    {
        /*
        if (!DataSaverLoader.LoadData())
        {
            DataSaverLoader.NewData();
        }
        //DataSaverLoader.SortData(false, 1);

        for (int i = 0; i < DataSaverLoader.Gd.Scoreboards[1].Slots.Length; i++)
        {
            Debug.Log("                 Level: 2                      #" + (i + 1) + " Ranked -> PlayerName: "
                + DataSaverLoader.Gd.Scoreboards[1].Slots[i].PlayerName + "    Score: " + DataSaverLoader.Gd.Scoreboards[1].Slots[i].Score);
        }

        */
    }
}
