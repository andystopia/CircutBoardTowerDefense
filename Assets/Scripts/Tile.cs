using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject highlightTileWhite;
    public GameObject highlightTileGreen;
    public GameObject highlightTileRed;

    public GameObject turret;

    private GameManager gameManagerScript;
    private TurretShop turretShopScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if(turret == null && gameManagerScript.selectedTurret != null)      //AND price is good     //have a better system for these
        {
            highlightTileGreen.gameObject.SetActive(true);
        } else if(turret != null && gameManagerScript.selectedTurret != null)   //OR ^^ + price is bad
        {
            highlightTileRed.gameObject.SetActive(true);
        } else
        {
            highlightTileWhite.gameObject.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        highlightTileWhite.gameObject.SetActive(false);
        highlightTileGreen.gameObject.SetActive(false);
        highlightTileRed.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        if(turret == null && gameManagerScript.selectedTurret != null)     //AND price is good
        {
            turret = gameManagerScript.selectedTurret;
            //substract price here
            Vector3 spawnPos = new Vector3(transform.position.x, -0.5f, transform.position.z);
            Instantiate(turret, spawnPos, transform.rotation);

        } else if(turret != null && gameManagerScript.selectedTurret != null)
        {
            //display "you can't place that here"
            Debug.Log("You can't place that here");
        } else if(turret == null && gameManagerScript.selectedTurret != null)   //AND price is bad
        {
            //display "you can't afford that"
            Debug.Log("You can't afford that"); //this should be checked in the TURRET SHOP TO BEGIN WITH (delete OR ^^ part above)
        } else if(turret == null && gameManagerScript.selectedTurret == null)
        {
            //put up a UI display to delete the turret to get a refund
        }
        

    }


}
