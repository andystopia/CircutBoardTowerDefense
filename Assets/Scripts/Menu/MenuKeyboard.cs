using System.Collections;
using System.Collections.Generic;
using KeyboardEventSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuKeyboard : MonoBehaviour
{
    public MenuButton[] buttons;
    public GameObject LSelect;
    public int currentSelection;

    public bool isActive;
    private bool isLSelect;

    void Awake()
    {
        currentSelection = 1; //Keep this at 0 for Browser build or else it can mess up Mouse Controls on the menu

        isActive = true;
        

        if (buttons.Length > 4)
        {
            isLSelect = true;
        }
        else isLSelect = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (KeyMap.ActiveMap.MainMenuMove.West.WasPressedThisFrame())
        {
            isActive = true;
            currentSelection -= 1;
            if (currentSelection <= 0)
            {
                currentSelection = 3;
            }
            else if (isLSelect && currentSelection == 3)
            {
                currentSelection = 6;
            }
        }

        if (KeyMap.ActiveMap.MainMenuMove.East.WasPressedThisFrame())
        {
            isActive = true;
            currentSelection += 1;
            if (currentSelection == 4)
            {
                currentSelection = 1;
            }
            else if (currentSelection == 7)
            {
                currentSelection = 4;
            }
        }

        if (KeyMap.ActiveMap.MainMenuMove.North.WasPressedThisFrame() && isLSelect)
        {
            isActive = true;
            currentSelection -= 3;
            if (currentSelection <= 0)
            {
                currentSelection += 6;
            }
        }

        if (KeyMap.ActiveMap.MainMenuMove.South.WasPressedThisFrame() && isLSelect)
        {
            isActive = true;
            currentSelection += 3;
            if (currentSelection >= 7)
            {
                currentSelection -= 6;
            }
        }

        if (KeyMap.ActiveMap.ClickKey.WasPressedThisFrame())
        {
            isActive = true;
            buttons[currentSelection].UseButton();
        }

        if (KeyMap.ActiveMap.CancelOperationKey.WasPressedThisFrame())
        {
            Application.Quit();
        }

        if (KeyMap.ActiveMap.MenuAndBack.WasPressedThisFrame())
        {
            SceneManager.LoadScene(0);
        }

        if (KeyMap.ActiveMap.ShowScoreboard.WasPressedThisFrame() && isLSelect && currentSelection > 0)
        {
            LoadScoreBoardDisplayScreen(currentSelection);
        }

        if (isActive) UpdateButtons();
    }

    void UpdateButtons()
    {
        for (var i = 1; i < buttons.Length; i++)
        {
            if (currentSelection == i)
            {
                buttons[i].isSelected = true;
            }
            else buttons[i].isSelected = false;
        }
    }

    public void DisableAllButtons()
    {
        for (var i = 1; i < buttons.Length; i++)
        {
            buttons[i].isSelected = false;
        }
    }

    void LoadScoreBoardDisplayScreen(int Level)
    {
        DataSaverLoader.Gd.LatestLevel = Level;
        DataSaverLoader.SaveData();
        SceneManager.LoadScene(8);
    }
}
