using System.Collections.Generic;
using System.Linq;
using PrimitiveFocus;

/// <summary>
/// Calculates a tile grid
/// from a given exclusion
/// area list, which allows
/// us to not put turrets where
/// we don't want them.
/// </summary>
public class ExclusionCheckedTileGridInstantiationCreator : TileInstantiationCreator
{
    private readonly ICollection<IExclusionZone> exclusionZones;
    
    /// <summary>
    /// Constructs a new tile grid instantiation creator
    /// given a few arguments which will be useful for
    /// creating tiles.
    /// </summary>
    /// <param name="gameManager"></param>
    /// <param name="tileSelectionManager"></param>
    /// <param name="tileFocusManager"></param>
    /// <param name="exclusionZones"></param>
    public ExclusionCheckedTileGridInstantiationCreator(GameManager gameManager, TileSelectionManager tileSelectionManager, ExclusiveSubsectionFocusManager tileFocusManager, ICollection<IExclusionZone> exclusionZones) : base(gameManager, tileSelectionManager, tileFocusManager)
    {
        this.exclusionZones = exclusionZones;
    }

    /// <summary>
    /// determines whether its legal to place a tile here
    /// </summary>
    /// <param name="location"></param>
    /// <returns>true if we can't place a tile, else false</returns>
    private bool IsLocationExcluded(Location<int> location)
    {
        return exclusionZones.Any(zone => zone.IsInZone(location));
    }

    /// <summary>
    /// Creates a new instance of a tile
    /// if it's legal to place one there.
    /// </summary>
    /// <param name="grid"></param>
    /// <param name="location"></param>
    /// <returns></returns>
    public override Tile CreateInstance(PrefabGrid<Tile> grid, Location<int> location)
    {
        if (IsLocationExcluded(location)) return null;
        return base.CreateInstance(grid, location);
    }
}