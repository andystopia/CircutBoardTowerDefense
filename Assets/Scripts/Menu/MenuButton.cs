using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public GameObject hover;
    public GameObject text;
    public bool isSelected;

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
    }

    void OnMouseEnter()
    {
        isSelected = true;
    }

    void OnMouseExit()
    {
        isSelected = false;
    }
}
