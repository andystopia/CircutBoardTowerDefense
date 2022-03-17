using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public GameObject hover;
    public GameObject text;
    public GameObject credits;

    public GameObject menu;
    public GameObject menu2;
    public bool isSelected;

    public int buttonID; //1 = play, 2 = howto, 3 = quit, 4 = levelselect
    public int sceneID; //0 = Main Menu, 1 = Level 1, 2 = Level 2, etc

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
            Debug.Log("Used");
            UseButton();
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

    public void UseButton()
    {
        if (buttonID == 1)
        {
            menu.GetComponent<MenuKeyboard>().LSelect.SetActive(true);
            menu.SetActive(false);
            menu2.SetActive(false);
        }

        if (buttonID == 2)
        {
            menu2.SetActive(true);
            credits.SetActive(false);
        }

        if (buttonID == 3)
        {
            Application.Quit();
        }

        if (buttonID == 4)
        {
            SceneManager.LoadScene(sceneID);
        }
    }
}
