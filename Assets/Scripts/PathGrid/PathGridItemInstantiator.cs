using GameGrid;
using UnityEngine;

namespace PathGrid
{
    public class PathGridItemInstantiator : IGridInstantiationCreator<PathGridItem>
    {
        public PathGridItem CreateInstance(PrefabGrid<PathGridItem> grid, GridLocation location)
        {
            return Object.Instantiate(grid.Prefab, GridSpaceGlobalSpaceConverter.FromLocation(location, 0.45f),
                Quaternion.identity);
        }
    }
}