using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShop : MonoBehaviour
{
    public Turret shopTurret;
    public GameObject litDisplay;
    public GameObject deleteDisplay;
    public GameObject turretMouseDrag;
    public FullTurretShop shop;

    public float energyCost;

    private GameManager gameManagerScript;

  

    /// <summary>
    /// A reference to another time in the turret shop.
    /// </summary>    
    public GameObject otherShop1;
    /// <summary>
    /// A reference to yet another item in the turret shop.
    /// </summary>
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

    private bool IsSelected()
    {
        return ReferenceEquals(shop.SelectedShop, this);
    }

    private void OnMouseDown()
    {
        if (!gameManagerScript.inTileMenu)
        {
            //    if (!hasBeenSelected)
            //    {
            //        gameManagerScript.selectedTurret = shopTurret;
            //        litDisplay.SetActive(true);
            //        hasBeenSelected = true;
            //        otherShop1Script.litDisplay.SetActive(false);
            //        otherShop2Script.litDisplay.SetActive(false);
            //        otherShop1Script.hasBeenSelected = false;
            //        otherShop2Script.hasBeenSelected = false;
            //        //spawn in the thing that follows you (inside the scirpt it follows the mouse + kills itself if selectedTurret null)
            //    }
            //    else
            //    {
            //        gameManagerScript.selectedTurret = null;
            //        litDisplay.SetActive(false);
            //        hasBeenSelected = false;
            //        deleteDisplay.SetActive(false);
            //    }
            //}
            shop.ToggleActiveShop(this);
        }
    }

    void OnMouseEnter()
    {
        if (IsSelected() && !gameManagerScript.inTileMenu)
        {
            deleteDisplay.SetActive(true);
        }
    }

    void OnMouseExit()
    {
        deleteDisplay.SetActive(false);
    }
}
