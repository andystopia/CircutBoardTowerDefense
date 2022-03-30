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
        Gd.Scoreboards = new Scoreboard[6];
        for(int i = 0; i < Gd.Scoreboards.Length; i++)
        {
            Gd.Scoreboards[i].Slots = new ScoreboardSlot[10];
            for(int j = 0; j < Gd.Scoreboards[i].Slots.Length; j++)
            {
                Gd.Scoreboards[i].Slots[j].PlayerName = "TESTER" + (j).ToString();
                Gd.Scoreboards[i].Slots[j].Score = Random.Range(100, 200 * (j + 1));
            }
            SortData(i + 1);
        }
    }

    public static void SortData(int Level)
    {
        bool Sorted = false;
        while(!Sorted)
        {
            Sorted = true;
            for (int i = Gd.Scoreboards[Level - 1].Slots.Length - 1; i > 0; i--)
            {
                if (Gd.Scoreboards[Level - 1].Slots[i].Score > Gd.Scoreboards[Level - 1].Slots[i - 1].Score)
                {
                    Sorted = false;
                    ScoreboardSlot temp = Gd.Scoreboards[Level - 1].Slots[i];
                    Gd.Scoreboards[Level - 1].Slots[i] = Gd.Scoreboards[Level - 1].Slots[i - 1];
                    Gd.Scoreboards[Level - 1].Slots[i - 1] = temp;
                }
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
