using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject nextNode;
    private Motherboard motherboardScript;
    private EnergyCounter energyCounterScript;
    private GameManager gameManagerScript;
    public float energyDrop;
    public float energyGain;
    public float health;
    public float healthGain;
    public float armySize;
    public float armySizeGain;
    public float speed;
    public float spawnRate;
    public float damageValue;

    public List<GameObject> tilesToDisable;
    public bool isExploding;
    public GameObject deactivator;

    // Start is called before the first frame update
    void Start()
    {
        energyCounterScript = GameObject.Find("Energy Counter").GetComponent<EnergyCounter>();
        motherboardScript = GameObject.Find("Motherboard").GetComponent<Motherboard>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, nextNode.transform.position, speed * Time.deltaTime);
        if (health <= 0)
        {
            //chance for spawning a chip
            energyCounterScript.energy += energyDrop;
            if (isExploding)
            {
                //particle effect
                explodeEnemy();
            }
            Destroy(gameObject);
            return;
        }

        if (transform.position.z < -9.5)
        {
            motherboardScript.hp -= damageValue;
            Destroy(gameObject);
        }
    }


    public void explodeEnemy()
    {

        //Instantiate(deactivator, transform.position, Quaternion.identity);







        
        //particle effect here
        Debug.Log("working");

        for (int i = 0; i < gameManagerScript.gameBoard.GetLength(0); i++)
        {
            for (int r = 0; r < gameManagerScript.gameBoard.GetLength(1); r++)
            {
                

                if (gameManagerScript.gameBoard[i, r] != null)
                {

                    //THE PROBLEM IS HERE \/ \/
                    Debug.Log("gameboard " + gameManagerScript.gameBoard[i, r].transform.position);
                    float distanceToTile = Vector3.Distance(gameManagerScript.gameBoard[i, r].transform.position, transform.position);
                    //Vector3 difference = new Vector3(gameManagerScript.gameBoard[i, r].transform.position.x - transform.position.x, gameManagerScript.gameBoard[i, r].transform.position.y - transform.position.y, gameManagerScript.gameBoard[i, r].transform.position.z - transform.position.z);
                    //float distanceToTile = Mathf.Sqrt(Mathf.Pow(difference.x, 2f) + Mathf.Pow(difference.y, 2f) + Mathf.Pow(difference.z, 2f));
                    Debug.Log("DistanceToTile [" + i + ", " + r + "] = " + distanceToTile);

                    if (distanceToTile <= 3.2f)
                    {
                        tilesToDisable.Add(gameManagerScript.gameBoard[i, r]);
                    }

                }
            }
        }

        foreach (GameObject tile in tilesToDisable)
        {
            Debug.Log("disabling a Tile");
            //tile.gameObject.GetComponent<Tile>().disableTileTemp();
        }
        
    }






















}
