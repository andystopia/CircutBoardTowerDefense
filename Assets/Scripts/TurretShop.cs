using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShop : MonoBehaviour
{
    public GameObject shopTurret;
    public GameObject litDisplay;
    public GameObject deleteDisplay;
    public GameObject turretMouseDrag;
    public bool hasBeenSelected;

    public float energyCost;

    private GameManager gameManagerScript;
    public GameObject otherShop1;
    public GameObject otherShop2;
    private TurretShop otherShop1Script;
    private TurretShop otherShop2Script;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        otherShop1Script = otherShop1.GetComponent<TurretShop>();
        otherShop2Script = otherShop2.GetComponent<TurretShop>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!gameManagerScript.inTileMenu)
        {
            if (!hasBeenSelected)
            {
                gameManagerScript.selectedTurret = shopTurret;
                litDisplay.SetActive(true);
                hasBeenSelected = true;
                otherShop1Script.litDisplay.SetActive(false);
                otherShop2Script.litDisplay.SetActive(false);
                otherShop1Script.hasBeenSelected = false;
                otherShop2Script.hasBeenSelected = false;
                //spawn in the thing that follows you (inside the scirpt it follows you + kills itself if selectedTurret null)
            }
            else
            {
                gameManagerScript.selectedTurret = null;
                litDisplay.SetActive(false);
                hasBeenSelected = false;
                deleteDisplay.SetActive(false);
            }
        }
    }

    private void OnMouseEnter()
    {
        if (hasBeenSelected && !gameManagerScript.inTileMenu)
        {
            deleteDisplay.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        deleteDisplay.SetActive(false);
    }


}
