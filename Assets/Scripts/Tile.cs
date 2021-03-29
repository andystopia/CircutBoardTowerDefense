using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Light mouseOverTileLight;
    public Light mouseOverViableTile;
    public Light mouseOverNotViableTile;

    public GameObject turret;

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

    private void OnMouseEnter()
    {
        if(turret == null && gameManagerScript.selectedTurret != null)      //AND price is good
        {
            mouseOverViableTile.gameObject.SetActive(true);
        } else if(turret != null && gameManagerScript.selectedTurret != null)   //OR ^^ + price is bad
        {
            mouseOverNotViableTile.gameObject.SetActive(true);
        } else
        {
            mouseOverTileLight.gameObject.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        mouseOverTileLight.gameObject.SetActive(false);
        mouseOverViableTile.gameObject.SetActive(false);
        mouseOverNotViableTile.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        if(turret == null && gameManagerScript.selectedTurret != null )     //AND price is good
        {
            turret = gameManagerScript.selectedTurret;
            //substract price here
            gameManagerScript.selectedTurret = null;
            Instantiate(turret, transform.position, Quaternion.identity);

        } else if(turret != null && gameManagerScript.selectedTurret != null)
        {
            //display "you can't place that here"
            Debug.Log("You can't place that here");
        } else if(turret == null && gameManagerScript.selectedTurret != null)   //AND price is bad
        {
            //display "you can't afford that"
            Debug.Log("You can't afford that"); //this should be checked in the TURRET SHOP TO BEGIN WITH (delete OR ^^ part above)
        }
        
        //have a delete tile to destroy the object if they don't want it

    }


}
