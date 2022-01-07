using PrimitiveFocus;

/// <summary>
/// Creates a grid of tiles
/// wherever there is not a null
/// location in the array.
/// </summary>
public class NaiveTileGridInstantiationCreator : TileInstantiationCreator
{
    public NaiveTileGridInstantiationCreator(GameManager gameManager, TileSelectionManager tileSelectionManager, ExclusiveSubsectionFocusManager tileFocusManager) : base(gameManager, tileSelectionManager, tileFocusManager)
    {
    }

    public override Tile CreateInstance(PrefabGrid<Tile> grid, Location<int> location)
    {
        if (grid[location] == null) return null;
        return base.CreateInstance(grid, location);
    }
}