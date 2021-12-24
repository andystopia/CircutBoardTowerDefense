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

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
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
