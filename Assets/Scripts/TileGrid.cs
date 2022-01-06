using ActiveOrInactiveStateManagement;
using PrimitiveFocus;
using UnityEngine;


public class TileGrid
{
    private const int numberOfColumns = 21;
    private const int numberOfRows = 13;
    private readonly GameManager gameManager;
    private readonly TileSelectionManager tileSelectionManager;
    private readonly ExclusiveSubsectionFocusManager tileFocusManager;
    private readonly Tile tilePrefab;
    public Dimensions<int> Dimensions { get; }

    private readonly ITileSelectionInteraction tileSelectionBehaviour;

    private readonly Tile[,] gameBoard;

    public TileGrid(GameManager gameManager, TileSelectionManager tileSelectionManager, TileFocusManager tileFocusManager, Tile tilePrefab)
    {
        gameBoard  = new Tile[numberOfColumns, numberOfRows];
        Dimensions = new Dimensions<int>(numberOfColumns, numberOfRows);
        this.gameManager = gameManager;
        this.tileSelectionManager = tileSelectionManager;
        this.tilePrefab = tilePrefab;
        tileSelectionBehaviour = tilePrefab.GetComponent<ITileSelectionInteraction>();
        this.tileFocusManager = tileFocusManager;
        
        InstantiateTiles();
        SpawnTiles();
    }

    private void InstantiateTiles()
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
        for(int i = 0; i < 10; i++)
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

        //MotherboardEntrance
        gameBoard[14, 0] = null;
        gameBoard[15, 0] = null;
        gameBoard[17, 0] = null;
        gameBoard[18, 0] = null;

        //Wave number
        gameBoard[5, 12] = null;
        gameBoard[6, 12] = null;
    }

    public Tile this[Location<int> location]
    {
        get => gameBoard[location.column, location.row];
        set => gameBoard[location.column, location.row] = value;
    }
    
    
    /// <summary>
    /// Will generate a valid location that is
    /// within the board. However, there
    /// might not be a tile at that location.
    /// </summary>
    /// <returns></returns>
    private Location<int> GetRandomLocation()
    {
        return new Location<int>(Random.Range(0, Dimensions.height), Random.Range(0, Dimensions.height));
    }
    
    
    public bool IsLocationValid(Location<int> location)
    {
        return location.row < Dimensions.height && location.row >= 0 && location.column < Dimensions.width && location.column >= 0;
    }



    /// <summary>
    /// Generates a random tile
    /// </summary>
    /// <returns></returns>
    public Tile GetRandomTile()
    {
        Tile tile;
        do
        {
            tile = this[GetRandomLocation()];
        } while (tile == null);

        return tile;
    }

    private void SpawnTiles()
    {
        //spawn a centered board of tiles
        float offsetX = -15; 
        float offsetZ = -9f; 
        Vector3 spawnLoco;
        for (int col = 0; col < gameBoard.GetLength(0); col++)
        {
            for (int row = 0; row < gameBoard.GetLength(1); row++)
            {
                if(gameBoard[col, row] != null)
                {
                    spawnLoco = new Vector3((1.5f * col + offsetX), -0.15f, (1.5f * row + offsetZ));

                    // instantiate based on the default value in the array
                    // replacing the default with each unique instantiation.
                    
                    Tile currentTile = Object.Instantiate(tilePrefab, spawnLoco, Quaternion.identity, tileSelectionManager.transform);
                    // start initializing the components.
                    currentTile.GetComponent<ITileSelectionInteraction>().Init(gameManager.GetEnergyCounter(), gameManager.GetTurretShop(), tileSelectionManager, tileFocusManager);
                    currentTile.GetComponent<ITileFocusDisplay>().Init(gameManager.focus);
                    currentTile.GetComponent<IPrefabGridPositionedItem>().SetLocation(new Location<int>(row, col));
                    
                    // this is the one to focus on.
                    currentTile.GetComponent<IExclusiveFocusInteractor>().SetManager(tileFocusManager);
                    gameBoard[col, row] = currentTile;
                }
            }
        }
    }
}