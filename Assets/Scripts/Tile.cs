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



    public TileMenu tileMenuScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        energyCounterScript = GameObject.Find("Energy Counter").GetComponent<EnergyCounter>();
        tileMenuScript = GameObject.Find("TileMenu").GetComponent<TileMenu>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseEnter()
    {
        if (!gameManagerScript.gameOver || !gameManagerScript.inTileMenu)
        {
            if (turret == null)
            {
                if (gameManagerScript.selectedTurret != null)
                {
                    if (gameManagerScript.selectedTurret.GetComponent<Turret>().energyCost <= energyCounterScript.energy)
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
            {
                if (gameManagerScript.selectedTurret != null)
                {
                    highlightTileRed.gameObject.SetActive(true);
                }
                else
                {
                    highlightTileWhite.gameObject.SetActive(true);
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
                    Debug.Log("Open Refund Menu DELETE ONCE DONE");
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
        gameManagerScript.inTileMenu = true;
        tileMenuScript.show();
        tileMenuScript.tileOpened = gameObject;     //that does this tile, right?
    }


    public void closeTileMenu()
    {
        gameManagerScript.inTileMenu = false;
        tileMenuScript.hide();
        
    }





}
