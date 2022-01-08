using PrimitiveFocus;
using UnityEngine;

namespace GameGrid
{
    /// <summary>
    /// This is a class which holds only the
    /// very fundamental aspects of what it
    /// means to create a tile and map its
    /// position from local grid space
    /// to word space, as well as
    /// initialize all its components.
    /// </summary>
    public class TileInstantiationCreator : IGridInstantiationCreator<Tile.Tile>
    {
        protected readonly GameManager gameManager;
        protected readonly TileSelectionManager tileSelectionManager;
        protected readonly ExclusiveSubsectionFocusManager tileFocusManager;

        /// <summary>
        /// Creates a new TileInstantiationCreator
        /// </summary>
        /// <param name="gameManager"></param>
        /// <param name="tileSelectionManager"></param>
        /// <param name="tileFocusManager"></param>
        public TileInstantiationCreator(GameManager gameManager, TileSelectionManager tileSelectionManager, ExclusiveSubsectionFocusManager tileFocusManager)
        {
            this.gameManager = gameManager;
            this.tileSelectionManager = tileSelectionManager;
            this.tileFocusManager = tileFocusManager;
        }

        protected const float offsetX = -15;
        protected const float offsetZ = -9f;

        /// <summary>
        /// Instantiates a new tile
        ///
        /// This method will translate the location
        /// in local grid space, into word space
        /// coordinates and then instantiate a tile
        /// there, after which it will initialize
        /// all the tile's components with all the
        /// data that they may need.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="location"> the local grid space location </param>
        /// <returns> a newly instantiated tile </returns>
        public virtual Tile.Tile CreateInstance(PrefabGrid<Tile.Tile> grid, GridLocation location)
        {
            var spawnLoco = GridSpaceGlobalSpaceConverter.FromLocation(location, -0.15f);
            
            var currentTile = Object.Instantiate(grid.Prefab, spawnLoco, Quaternion.identity, tileSelectionManager.transform);
            // initializing the components.
            currentTile.GetComponent<ITileSelectionInteractor>().Init(gameManager.GetEnergyCounter(),
                gameManager.GetTurretShop(), tileSelectionManager, tileFocusManager);
            currentTile.GetComponent<ITileFocusDisplay>().Init(gameManager.focus);
            currentTile.GetComponent<IPrefabGridPositionedItem>().SetLocation(location);
            currentTile.GetComponent<IExclusiveFocusInteractor>().SetManager(tileFocusManager);
            return currentTile;
        }
    }
}