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
            DataSaverLoader.Gd.LatestLevel = 1;
            SceneManager.LoadScene(8);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DataSaverLoader.Gd.LatestLevel = 2;
            SceneManager.LoadScene(8);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DataSaverLoader.Gd.LatestLevel = 3;
            SceneManager.LoadScene(8);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            DataSaverLoader.Gd.LatestLevel = 4;
            SceneManager.LoadScene(8);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            DataSaverLoader.Gd.LatestLevel = 4;
            SceneManager.LoadScene(8);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            DataSaverLoader.Gd.LatestLevel = 5;
            SceneManager.LoadScene(8);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            DataSaverLoader.Gd.LatestLevel = 6;
            SceneManager.LoadScene(8);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SceneManager.LoadScene(0);
        }
    }
}
