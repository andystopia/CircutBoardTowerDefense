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
    private EnergyCounter energyCounterScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        energyCounterScript = GameObject.Find("Energy Counter").GetComponent<EnergyCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if(turret == null)
        {
            if(gameManagerScript.selectedTurret != null)
            {
                if(gameManagerScript.selectedTurret.GetComponent<Turret>().energyCost <= energyCounterScript.energy)
                {
                    highlightTileGreen.gameObject.SetActive(true);
                } else
                {
                    highlightTileRed.gameObject.SetActive(true);
                }
            } else
            {
                highlightTileWhite.gameObject.SetActive(true);
            }
        } else
        {
            if(gameManagerScript.selectedTurret != null)
            {
                highlightTileRed.gameObject.SetActive(true);
            } else
            {
                highlightTileWhite.gameObject.SetActive(true);
            }
        }
        /*
        if(turret == null && gameManagerScript.selectedTurret != null)
        {
            if(gameManagerScript.selectedTurret.GetComponent<Turret>().energyCost <= energyCounterScript.energy)
            {
                highlightTileGreen.gameObject.SetActive(true);
            }
        } else if(gameManagerScript.selectedTurret != null)
        {
            if(turret != null)
            {
                highlightTileRed.gameObject.SetActive(true);
            } else if(gameManagerScript.selectedTurret.GetComponent<Turret>().energyCost >= energyCounterScript.energy)
            {
                highlightTileRed.gameObject.SetActive(true);
            }
        } else
        {
            highlightTileWhite.gameObject.SetActive(true);
        }
        */
    }

    private void OnMouseExit()
    {
        highlightTileWhite.gameObject.SetActive(false);
        highlightTileGreen.gameObject.SetActive(false);
        highlightTileRed.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (turret == null)
        {
            if (gameManagerScript.selectedTurret != null)
            {
                if (gameManagerScript.selectedTurret.GetComponent<Turret>().energyCost <= energyCounterScript.energy)
                {
                    turret = gameManagerScript.selectedTurret;
                    energyCounterScript.energy -= turret.GetComponent<Turret>().energyCost;
                    Vector3 spawnPos = new Vector3(transform.position.x, -0.5f, transform.position.z);
                    Instantiate(turret, spawnPos, transform.rotation);
                }
                else
                {
                    //display "you can't afford that"
                    Debug.Log("You can't afford that");
                }
            }
        }
        else
        {
            if (gameManagerScript.selectedTurret != null)
            {
                //display "you can't place that here"
                Debug.Log("You can't place that here");
            }
            else
            {
                //open UI thing
                Debug.Log("Open Refund Menu");
            }
        }       
    }


}
