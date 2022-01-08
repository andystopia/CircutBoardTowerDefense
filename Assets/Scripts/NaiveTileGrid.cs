using PrimitiveFocus;

/// <summary>
/// This represents a naive tile grid
/// which calculates a massive array
/// of prefab or null which defines
/// the exclusion mask of where
/// we cannot place turrets.
/// </summary>
public class NaiveTileGrid : PrefabGrid<Tile.Tile>
{
    private const int cols = 21;
    private const int rows = 13;
    
    /// <summary>
    /// Construct a new NaiveTileGrid
    /// </summary>
    /// <param name="gameManager"></param>
    /// <param name="tileSelectionManager"></param>
    /// <param name="tileFocusManager"></param>
    /// <param name="prefab"></param>
    public NaiveTileGrid(GameManager gameManager, TileSelectionManager tileSelectionManager, ExclusiveSubsectionFocusManager tileFocusManager, Tile.Tile prefab) : base(GetTemplate(rows, cols, prefab), prefab)
    {
        GridInstantiate(new NaiveTileGridInstantiationCreator(gameManager, tileSelectionManager, tileFocusManager));
    }

    /// <summary>
    /// Creates the template by which the array is built.
    /// </summary>
    /// <param name="creationRows"></param>
    /// <param name="creationCols"></param>
    /// <param name="prefab"></param>
    /// <returns></returns>
    private static Tile.Tile[,] GetTemplate(int creationRows, int creationCols, Tile.Tile prefab)
    {
        var tiles = new Tile.Tile[creationCols, creationRows];
        
        for (int i = 0; i < tiles.GetLength(0); i++)
        {
            for (int r = 0; r < tiles.GetLength(1); r++)
            {
                tiles[i, r] = prefab;
            }
        }
        //pathway one
        tiles[2, 12] = null;
        tiles[2, 11] = null;
        tiles[2, 10] = null;
        tiles[2, 9] = null;
        tiles[2, 8] = null;
        tiles[2, 7] = null;
        //2
        tiles[3, 7] = null;
        tiles[4, 7] = null;
        tiles[5, 7] = null;
        tiles[6, 7] = null;
        tiles[7, 7] = null;
        //3
        tiles[7, 6] = null;
        tiles[7, 5] = null;
        //4
        tiles[8, 5] = null;
        tiles[9, 5] = null;
        tiles[10, 5] = null;
        tiles[11, 5] = null;
        //5
        tiles[11, 6] = null;
        tiles[11, 7] = null;
        tiles[11, 8] = null;
        //6
        tiles[12, 8] = null;
        tiles[13, 8] = null;
        //7
        tiles[13, 9] = null;
        tiles[13, 10] = null;
        //8
        tiles[14, 10] = null;
        tiles[15, 10] = null;
        tiles[16, 10] = null;
        tiles[17, 10] = null;
        tiles[18, 10] = null;
        //9
        tiles[18, 9] = null;
        tiles[18, 8] = null;
        tiles[18, 7] = null;
        tiles[18, 6] = null;
        tiles[18, 5] = null;
        //10
        tiles[17, 5] = null;
        tiles[16, 5] = null;
        // 11 
        tiles[16, 4] = null;
        tiles[16, 3] = null;
        tiles[16, 2] = null;
        tiles[16, 1] = null;
        tiles[16, 0] = null;


        //Turret menu
        for(int i = 0; i < 10; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                tiles[i, j] = null;
            }
        }
        //EnergyCounter
        tiles[0, 3] = null;
        tiles[1, 3] = null;
        tiles[2, 3] = null;
        tiles[3, 3] = null;

        //EnemySpawner
        tiles[0, 12] = null;
        tiles[1, 12] = null;
        tiles[3, 12] = null;
        tiles[4, 12] = null;

        //MotherboardEntrance
        tiles[14, 0] = null;
        tiles[15, 0] = null;
        tiles[17, 0] = null;
        tiles[18, 0] = null;

        //Wave number
        tiles[5, 12] = null;
        tiles[6, 12] = null;
        return tiles;
    }
}