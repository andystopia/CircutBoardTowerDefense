using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[,] gameBoard = new GameObject[21, 13];
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
        //pathway one
        gameBoard[2, 12] = null;
        gameBoard[2, 11] = null;
        gameBoard[2, 10] = null;
        gameBoard[2, 9] = null;
        gameBoard[2, 8] = null;
        gameBoard[2, 7] = null;
        //2
        gameBoard[3, 7] = null;
        gameBoard[4, 7] = null;
        gameBoard[5, 7] = null;
        gameBoard[6, 7] = null;
        gameBoard[7, 7] = null;
        //3
        gameBoard[7, 6] = null;
        gameBoard[7, 5] = null;
        //4
        gameBoard[8, 5] = null;
        gameBoard[9, 5] = null;
        gameBoard[10, 5] = null;
        gameBoard[11, 5] = null;
        //5
        gameBoard[11, 6] = null;
        gameBoard[11, 7] = null;
        gameBoard[11, 8] = null;
        //6
        gameBoard[12, 8] = null;
        gameBoard[13, 8] = null;
        //7
        gameBoard[13, 9] = null;
        gameBoard[13, 10] = null;
        //8
        gameBoard[14, 10] = null;
        gameBoard[15, 10] = null;
        gameBoard[16, 10] = null;
        gameBoard[17, 10] = null;
        gameBoard[18, 10] = null;
        //9
        gameBoard[18, 9] = null;
        gameBoard[18, 8] = null;
        gameBoard[18, 7] = null;
        gameBoard[18, 6] = null;
        gameBoard[18, 5] = null;
        //10
        gameBoard[17, 5] = null;
        gameBoard[16, 5] = null;
        gameBoard[16, 4] = null;
        gameBoard[16, 3] = null;
        gameBoard[16, 2] = null;
        gameBoard[16, 1] = null;
        gameBoard[16, 0] = null;


        //Turret menu
        for(int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                gameBoard[i, j] = null;
            }
        }
        //EnergyCounter
        gameBoard[0, 3] = null;
        gameBoard[1, 3] = null;
        gameBoard[2, 3] = null;
        gameBoard[3, 3] = null;

        //EnemySpawner
        gameBoard[0, 12] = null;
        gameBoard[1, 12] = null;
        gameBoard[3, 12] = null;
        gameBoard[4, 12] = null;

        //MotherboardEnterance
        gameBoard[14, 0] = null;
        gameBoard[15, 0] = null;
        gameBoard[17, 0] = null;
        gameBoard[18, 0] = null;
    }


    //spawns in gameBoard's Tiles
    void spawnInTiles()
    {
        //spawn a centered board of tiles
        float offsetX = -15; 
        float offsetZ = -9f; 
        Vector3 spawnLoco;
        for (int i = 0; i < gameBoard.GetLength(0); i++)
        {
            for (int r = 0; r < gameBoard.GetLength(1); r++)
            {
                if(gameBoard[i, r] != null)
                {
                    spawnLoco = new Vector3((1.5f * i + offsetX), -0.15f, (1.5f * r + offsetZ));
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
