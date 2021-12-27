using System;
using UnityEngine;
using Random = System.Random;

public class Tile : MonoBehaviour, IFocusable
{
    public GameObject rangeIndicator;

    public GameObject tileText;

    public Turret turret;

    private GameManager gameManagerScript;
    private EnergyCounter energyCounterScript;



    public TileMenu myTileMenu;
    private Location<int> location;

    public Location<int> Location { get => location; set => location = value; }


    private MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        energyCounterScript = GameObject.Find("Energy Counter").GetComponent<EnergyCounter>();
        meshRenderer = GetComponent<MeshRenderer>();
        //tileMenuScript = GameObject.Find("TileMenu").GetComponent<TileMenu>();
        myTileMenu.hide();
    }

    // Update is called once per frame
    void Update()
    {
    }



    public void OnMouseEnter()
    {
        gameManagerScript.tileManager.Selected = this;
    }

    public void Hovered()
    {
        if (!gameManagerScript.gameOver || !gameManagerScript.inTileMenu)
        {
            // gameManagerScript.focus.FocusOn(this);
            // gameManagerScript.focus.FocusOn(this, new Color((float) random.NextDouble(), (float) random.NextDouble(), (float) random.NextDouble()));
            if (turret == null) //if the tile has no turret in it
            {
                if (gameManagerScript.turretShop.SelectedShop != null)
                {
                    if (gameManagerScript.turretShop.SelectedShop.energyCost <= energyCounterScript.energy)
                    {
                        gameManagerScript.focus.FocusOn(this, Color.green);
                        // highlightTileGreen.gameObject.SetActive(true);
                        rangeIndicator.gameObject.SetActive(true);
                        rangeIndicator.transform.localScale = new Vector3(gameManagerScript.turretShop.SelectedShop.shopTurret.range - 1, gameManagerScript.turretShop.SelectedShop.shopTurret.range - 1, 1);
                    }
                    else
                    {
                        gameManagerScript.focus.FocusOn(this, Color.red);
                        // highlightTileRed.gameObject.SetActive(true);
                    }
                }
                else
                {
                    gameManagerScript.focus.FocusOn(this, Color.white);
                    // highlightTileWhite.gameObject.SetActive(true);
                }
            }
            else
            {
                if (gameManagerScript.turretShop.SelectedShop != null)
                {
                    gameManagerScript.focus.FocusOn(this, Color.red);
                    // highlightTileRed.gameObject.SetActive(true);
                }
                else
                {   //if the player wants to select the tile to do tileMenu
                    gameManagerScript.focus.FocusOn(this, Color.white);
                }
            }
        }
    }

    private void OnMouseExit()
    {
        gameManagerScript.tileManager.EnsureDeselected(this);
    }

    public void Deselect()
    {
        gameManagerScript.focus.StopFocusOn(this);
    }

    private void OnMouseDown()
    {
        AttemptToPlaceTurret();
    }


    public void AttemptToPlaceTurret()
    {
        if (!gameManagerScript.gameOver || !gameManagerScript.inTileMenu)
        {
            if (turret == null)
            {

                if (gameManagerScript.turretShop.SelectedShop != null)
                {
                    if (gameManagerScript.turretShop.SelectedShop.energyCost <= energyCounterScript.energy)
                    {
                        turret = gameManagerScript.turretShop.SelectedShop.shopTurret;

                        energyCounterScript.energy -= gameManagerScript.turretShop.SelectedShop.energyCost;
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
                if (gameManagerScript.turretShop.SelectedShop != null)
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

    public Bounds FocusBounds => meshRenderer.bounds;
    public Vector3 FocusCenter => transform.position;
}
