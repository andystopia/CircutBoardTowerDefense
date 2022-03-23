using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class DataSaverLoader
{
    public static GameData Gd;


    public static void NewData()
    {
        Gd = new GameData();
        Gd.Scoreboards = new Scoreboard[5];
        for(int i = 0; i < Gd.Scoreboards.Length; i++)
        {
            Gd.Scoreboards[i].Slots = new ScoreboardSlot[9];
            for(int j = 0; j < Gd.Scoreboards[i].Slots.Length; j++)
            {
                Gd.Scoreboards[i].Slots[j].PlayerName = "TESTER" + (j + 1).ToString();
                Gd.Scoreboards[i].Slots[j].Score = Random.Range(100, 200 * (j + 1));
                
            }
            SortData(false, i + 1);
        }
    }

    public static void SortData(bool Sorted, int Level)
    {
        Debug.Log("\nREEE Level " + Level);
        for(int i = Gd.Scoreboards[Level - 1].Slots.Length - 2; i > 0; i--)
        {
            if(Gd.Scoreboards[Level - 1].Slots[i].Score < Gd.Scoreboards[Level - 1].Slots[i + 1].Score)
            {
                //swaps the scores
                int tempInt = Gd.Scoreboards[Level - 1].Slots[i].Score;
                Gd.Scoreboards[Level - 1].Slots[i].Score = Gd.Scoreboards[Level - 1].Slots[i + 1].Score;
                Gd.Scoreboards[Level - 1].Slots[i + 1].Score = tempInt;

                //swaps the names
                string tempString = Gd.Scoreboards[Level - 1].Slots[i].PlayerName;
                Gd.Scoreboards[Level - 1].Slots[i].PlayerName = Gd.Scoreboards[Level - 1].Slots[i + 1].PlayerName;
                Gd.Scoreboards[Level - 1].Slots[i + 1].PlayerName = tempString;
            }
            else if(Sorted)
            {
                //ends looping when a swap isn't needed anymore (when the array is already sorted)
                i = Gd.Scoreboards[Level - 1].Slots.Length;
            }
        }
    }

    public static void SaveData()
    {
        // Get path to the file we want to save
        string filePath = Application.persistentDataPath + "/save.data";
        // make a 'FileStream' with that path, and set the mode to FileMode.Create
        FileStream dataStream = new FileStream(filePath, FileMode.Create);
        // make a new binary formatter
        BinaryFormatter converter = new BinaryFormatter();
        // serialize a class marked with System.Serializable
        converter.Serialize(dataStream, Gd);
        // close the stream
        dataStream.Close();
    }

    public static bool LoadData()
    {
        string filePath = Application.persistentDataPath + "/save.data";
        //Debug.Log(filePath);

        if (File.Exists(filePath))
        {
            FileStream dataStream = new FileStream(filePath, FileMode.Open);
            BinaryFormatter converter = new BinaryFormatter();
            Gd = converter.Deserialize(dataStream) as GameData;
            dataStream.Close();

            return true;
        }
        else
        {
            return false;
        }
    }

}
