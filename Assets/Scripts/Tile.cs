using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject highlightTileWhite;
    public GameObject highlightTileGreen;
    public GameObject highlightTileRed;
    public GameObject rangeIndicator;

    public GameObject tileText;

    public GameObject turret;

    private GameManager gameManagerScript;
    private TurretShop turretShopScript;
    private EnergyCounter energyCounterScript;



    public TileMenu myTileMenu;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        energyCounterScript = GameObject.Find("Energy Counter").GetComponent<EnergyCounter>();
        //tileMenuScript = GameObject.Find("TileMenu").GetComponent<TileMenu>();
        myTileMenu.hide();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseEnter()
    {
        if (!gameManagerScript.gameOver || !gameManagerScript.inTileMenu)
        {
            if (turret == null) //if the tile has no turret in it
            {
                if (gameManagerScript.selectedTurret != null)   //if the player is about to place a turret
                {
                    if (gameManagerScript.selectedTurret.GetComponent<Turret>().energyCost <= energyCounterScript.energy)   //if the player can afford to place the tile
                    {
                        highlightTileGreen.gameObject.SetActive(true);
                        rangeIndicator.gameObject.SetActive(true);
                        rangeIndicator.transform.localScale = new Vector3(gameManagerScript.selectedTurret.GetComponent<Turret>().range - 1, gameManagerScript.selectedTurret.GetComponent<Turret>().range - 1, 1);

                    }
                    else
                    {
                        highlightTileRed.gameObject.SetActive(true);
                    }
                }
                else
                {
                    highlightTileWhite.gameObject.SetActive(true);
                }
            }
            else
            {   //if the tile has a turret in it
                if (gameManagerScript.selectedTurret != null)   //if the player is trying to place a turret
                {
                    highlightTileRed.gameObject.SetActive(true);
                }
                else
                {   //if the player wants to select the tile to do tileMenu
                    highlightTileWhite.gameObject.SetActive(true);      //WHY ISN'T this working???     <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
            }
        }
    }

    private void OnMouseExit()
    {
        highlightTileWhite.gameObject.SetActive(false);
        highlightTileGreen.gameObject.SetActive(false);
        highlightTileRed.gameObject.SetActive(false);
        rangeIndicator.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (!gameManagerScript.gameOver || !gameManagerScript.inTileMenu)
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
                        Vector3 spawnPos = new Vector3(0, 8, 0);
                        var gO = Instantiate(tileText, spawnPos, Quaternion.identity, transform);
                        gO.GetComponent<TextMesh>().text = "You Can't Afford That.";
                        gO.GetComponent<Transform>().rotation = new Quaternion(90, 0, 0, 90);
                    }
                }
            }
            else
            {
                if (gameManagerScript.selectedTurret != null)
                {
                    Vector3 spawnPos = new Vector3(0, 8, 0);
                    var gO = Instantiate(tileText, spawnPos, Quaternion.identity, transform);
                    gO.GetComponent<TextMesh>().text = "You Can't Place That Here.";
                    gO.GetComponent<Transform>().rotation = new Quaternion(90, 0, 0, 90);
                }
                else
                {
                    openTileMenu();


                }
            }
        }
    }

    void makeTileText(string theWords)
    {
        var gO = Instantiate(tileText, transform.position, Quaternion.identity, transform);
        gO.GetComponent<TextMesh>().text = "" + theWords;
    }


    void openTileMenu()
    {
        Debug.Log("Open Menu");
        gameManagerScript.inTileMenu = true;
        myTileMenu.show();
    }


    public void closeTileMenu()
    {
        gameManagerScript.inTileMenu = false;
        myTileMenu.hide();
        
    }





}
