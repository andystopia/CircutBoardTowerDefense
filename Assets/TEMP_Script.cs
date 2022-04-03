using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TEMP_Script : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            LoadScoreBoardDisplayScreen(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LoadScoreBoardDisplayScreen(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            LoadScoreBoardDisplayScreen(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            LoadScoreBoardDisplayScreen(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            LoadScoreBoardDisplayScreen(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            LoadScoreBoardDisplayScreen(6);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SceneManager.LoadScene(0);
        }
    }

    void LoadScoreBoardDisplayScreen(int Level)
    {
        DataSaverLoader.Gd.LatestLevel = Level;
        DataSaverLoader.SaveData();
        SceneManager.LoadScene(8);
    }

}
