using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMain : MonoBehaviour
{
    //This script simply returns to the Main Menu scene when C or Right click is pressed

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(DataSaverLoader.Gd.MenuAndBack))
        {
            SceneManager.LoadScene(0);
        }
    }
}
