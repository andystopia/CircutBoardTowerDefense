using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuKeyboard : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject LSelect;
    public int currentSelection;

    public bool isActive;
    private bool isLSelect;

    // Start is called before the first frame update
    void Start()
    {
        currentSelection = 0;
        isActive = false;
        for (var i = 1; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<MenuButton>();
        }

        if (buttons.Length > 4)
        {
            isLSelect = true;
        }
        else isLSelect = false;
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
            
            if (currentSelection == 3)
            {
                currentSelection = 6;
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

            if (currentSelection == 7)
            {
                currentSelection = 4;
            }
        }

        if (Input.GetKeyDown("w") && isLSelect)
        {
            isActive = true;
            currentSelection -= 3;
            if (currentSelection <= 0)
            {
                currentSelection += 6;
            }
        }

        if (Input.GetKeyDown("s") && isLSelect)
        {
            isActive = true;
            currentSelection += 3;
            if (currentSelection >= 7)
            {
                currentSelection -= 6;
            }
        }

        if (Input.GetKeyDown("space"))
        {
            isActive = true;
            if (currentSelection == 1)
            {
                LSelect.SetActive(true);
                gameObject.SetActive(false);
            }

            if (currentSelection == 2)
            {
                //display tutorial screen
            }

            if (currentSelection == 3)
            {
                Application.Quit();
            }

            if (currentSelection >= 4)
            {
                //go to selected scene
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
