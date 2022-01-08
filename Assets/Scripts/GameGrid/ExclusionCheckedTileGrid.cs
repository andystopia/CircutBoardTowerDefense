using System.Collections.Generic;
using PrimitiveFocus;

namespace GameGrid
{
    /// <summary>
    /// Represents a tile grid
    /// which is an array with
    /// certain sections excluded from it
    /// </summary>
    public class ExclusionCheckedTileGrid : PrefabGrid<Tile.Tile> {
        /// <summary>
        /// Creates a new exclusion checked tile grid.
        /// </summary>
        /// <param name="dimensions"></param>
        /// <param name="gameManager"></param>
        /// <param name="tileSelectionManager"></param>
        /// <param name="tileFocusManager"></param>
        /// <param name="prefab"></param>
        /// <param name="exclusionZones"></param>
        public ExclusionCheckedTileGrid(Dimensions<int> dimensions, GameManager gameManager, TileSelectionManager tileSelectionManager, ExclusiveSubsectionFocusManager tileFocusManager, Tile.Tile prefab, ICollection<IExclusionZone> exclusionZones) : base(dimensions, prefab)
        {
            GridInstantiate(new ExclusionCheckedTileGridInstantiationCreator(gameManager, tileSelectionManager, tileFocusManager, exclusionZones));
        }
    }
}