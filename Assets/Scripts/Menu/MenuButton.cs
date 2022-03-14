using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public GameObject hover;
    public GameObject text;

    public GameObject menu;
    public bool isSelected;

    public int buttonID; //1 = play, 2 = howto, 3 = quit

    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (isSelected)
        {
            hover.SetActive(true);
            text.SetActive(true);
        }
        else
        {
            hover.SetActive(false);
            text.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0) && isSelected)
        {
            if (buttonID == 1)
            {
                //level select
            }

            if (buttonID == 2)
            {
                //how to screen
            }

            if (buttonID == 3)
            {
                Application.Quit();
            }
        }
    }

    void OnMouseEnter()
    {
        menu.GetComponent<MenuKeyboard>().isActive = false;
        isSelected = true;
    }

    void OnMouseExit()
    {
        isSelected = false;
    }
}
