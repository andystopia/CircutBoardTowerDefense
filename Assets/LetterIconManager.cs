using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LetterIconManager : MonoBehaviour
{

    private string[] AlphabetAndNums = { "_", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
    [SerializeField] private GameObject[] LetterIcons;
    [SerializeField] private TextMeshPro SelectedLetterIcon;
    private int CurrentLetterIndex;
    private int SelectedLeterIconIndex;
    private bool Flip;
    private string FinalName;

    private void Start()
    {
        FinalName = "";
        CurrentLetterIndex = 0;
        SelectedLeterIconIndex = 0;
        InvokeRepeating("Blink", 0, 0.5f);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            CurrentLetterIndex++;
            CurrentLetterIndex = MyMod(CurrentLetterIndex, AlphabetAndNums.Length);
            SelectedLetterIcon.text = AlphabetAndNums[CurrentLetterIndex];
            SelectedLetterIcon.fontSize = 25;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            CurrentLetterIndex--;
            CurrentLetterIndex = MyMod(CurrentLetterIndex, AlphabetAndNums.Length);
            SelectedLetterIcon.text = AlphabetAndNums[CurrentLetterIndex];
            SelectedLetterIcon.fontSize = 25;
        }
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            CurrentLetterIndex = 0;
            FinalName = FinalName + SelectedLetterIcon.text;
            SelectedLeterIconIndex++;
            SelectedLetterIcon.fontSize = 25;
            if (SelectedLeterIconIndex < LetterIcons.Length)
            {
                SelectedLetterIcon = LetterIcons[SelectedLeterIconIndex].GetComponent<TextMeshPro>();
            }
            else
            {
                //PlayerPrefs.SetString("PLAYER_NAME", myList.Count);

                //Debug.Log(FinalName);
                //log things and go to main menu
                Debug.Log("WILL RUN STORING CODE HERE and STORE DATA::\n"
                            + "Level: " + PlayerPrefs.GetInt("TempLevelPlayed")
                            + "   PlayerScore: " + PlayerPrefs.GetInt("TempFinalScore")
                            + "   PlayerName: " + FinalName);
                SceneManager.LoadScene(0);
            }
        }



    }

    private void Blink()
    {
        if (Flip)
        {
            SelectedLetterIcon.fontSize = 23;
            Flip = false;
        }
        else
        {
            SelectedLetterIcon.fontSize = 25;
            Flip = true;
        }
    }

    private int MyMod(int num, int mod)
    {
        if (num <= 0)
        {
            return mod - 1;
        }
        else
        {
            return num % mod;
        }
    }



}
