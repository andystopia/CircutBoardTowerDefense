using System;
using System.Linq.Expressions;
using GameGrid;
using Helpers;
using UnityEngine;
using Object = UnityEngine.Object;

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