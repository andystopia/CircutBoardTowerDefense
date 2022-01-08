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
        private readonly CardinalDirection[] DIRECTIONS = {CardinalDirection.North, CardinalDirection.South, CardinalDirection.East, CardinalDirection.West};
        
        public PathGridItem CreateInstance(PrefabGrid<PathGridItem> grid, GridLocation location)
        {
            if (grid[location] == null) return null;
            
            var pathGridItem = Object.Instantiate(grid.Prefab, GridSpaceGlobalSpaceConverter.FromLocation(location, 0.45f),
                Quaternion.identity);
            
            foreach (var cardinalDirection in DIRECTIONS)
            {
                if (grid.GetOrNull(GridLocationTransform.ByCardinalDirection(location, cardinalDirection))) 
                {
                    pathGridItem.Enable(cardinalDirection);
                }
            }
            return pathGridItem;
        }
    }
}