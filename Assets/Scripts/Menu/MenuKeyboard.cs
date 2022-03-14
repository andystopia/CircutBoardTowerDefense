using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuKeyboard : MonoBehaviour
{
    public GameObject[] buttons;
    
    public int currentSelection;

    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        currentSelection = 0;
        isActive = false;
        for (var i = 1; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<MenuButton>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            isActive = true;
            currentSelection -= 1;
            if (currentSelection == 0)
            {
                currentSelection = 3;
            }
        }

        if (Input.GetKeyDown("d"))
        {
            isActive = true;
            currentSelection += 1;
            if (currentSelection == 4)
            {
                currentSelection = 1;
            }
        }

        if (Input.GetKeyDown("space"))
        {
            isActive = true;
            if (currentSelection == 1)
            {
                //go to level select
            }

            if (currentSelection == 2)
            {
                //display tutorial screen
            }

            if (currentSelection == 3)
            {
                Application.Quit();
            }
        }

        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }

        if (isActive) UpdateButtons();
    }

    void UpdateButtons()
    {
        for (var i = 1; i < buttons.Length; i++)
        {
            if (currentSelection == i)
            {
                buttons[i].GetComponent<MenuButton>().isSelected = true;
            }
            else buttons[i].GetComponent<MenuButton>().isSelected = false;
        }
    }
}
