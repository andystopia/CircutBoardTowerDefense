using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[,] gameBoard = new GameObject[10, 10];
    public GameObject tilePrefab;
    public GameObject selectedTurret;



    // Start is called before the first frame update
    void Start()
    {
        instantiateTiles();
        spawnInTiles();
    }

    //instantiates gameBoard
    void instantiateTiles()
    {
        for (int i = 0; i < gameBoard.GetLength(0); i++)
        {
            for (int r = 0; r < gameBoard.GetLength(1); r++)
            {
                gameBoard[i, r] = tilePrefab;
            }
        }
        gameBoard[1, 9] = null;
        gameBoard[1, 8] = null;
        gameBoard[1, 7] = null;
    }


    //spawns in gameBoard's Tiles
    void spawnInTiles()
    {
        //gets offset to the board is centered
        /*
        float offsetX = -gameBoard.GetLength(0) / 2.0f;
        Debug.Log(gameBoard.GetLength(0) + " this is getlength");
        Debug.Log("this isoffsetx = " + offsetX);
        float offsetZ = -gameBoard.GetLength(1) / 2.0f;
        */
        float offsetX = -4;              //temporary!
        float offsetZ = -4;              //temp!
        Vector3 spawnLoco;
        for (int i = 0; i < gameBoard.GetLength(0); i++)
        {
            for (int r = 0; r < gameBoard.GetLength(1); r++)
            {
                if(gameBoard[i, r] != null)
                {
                    spawnLoco = new Vector3((i + offsetX), 0, (r + offsetZ));
                    Instantiate(gameBoard[i, r], spawnLoco, Quaternion.identity);
                }
            }
        }
    }






    // Update is called once per frame
    void Update()
    {
        
    }
}
