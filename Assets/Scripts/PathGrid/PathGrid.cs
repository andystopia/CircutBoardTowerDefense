using System;
using System.Collections.Generic;
using GameGrid;
using UnityEngine;

namespace PathGrid
{
    public class PathGrid : PrefabGrid<PathGridItem>
    {
        public PathGrid(Dimensions<int> dimensions, EnemyPath path, PathGridItem prefab) : base(CreateTemplateArray(dimensions, path, prefab), prefab)
        {
            GridInstantiate(new PathGridItemInstantiator());
        }

        private static IEnumerator<GridLocation> GetLocationsBetween(GridLocation a, GridLocation b)
        {
            while (!a.Equals(b))
            {
                var columnDiff = b.Column - a.Column;
                var rowDiff = b.Row - a.Row;
                var colStep = Math.Sign(columnDiff);
                var rowStep = Math.Sign(rowDiff);

                if (Math.Abs(columnDiff) > Math.Abs(rowDiff))
                {
                    a = new GridLocation(a.Row, a.Column + colStep);
                    yield return a;
                }
                else
                {
                    a = new GridLocation(a.Row + rowStep, a.Column);
                    yield return a;
                }
            }
        }

        private static PathGridItem[,] CreateTemplateArray(Dimensions<int> dimensions, EnemyPath path, PathGridItem prefab)
        {
            PathGridItem[,] grid = new PathGridItem[dimensions.width, dimensions.height];

            for (var i = 0; i < path.Points.Count - 1; i++)
            {
                var firstPoint = path.Points[i];
                var secondPoint = path.Points[i + 1];

                grid[firstPoint.Column, firstPoint.Row] = prefab;
                
                var between = GetLocationsBetween(firstPoint, secondPoint);
                
                while (between.MoveNext())
                {
                    var loc = between.Current;
                    grid[loc.Column, loc.Row] = prefab;
                }

            }
            
            
            return grid;
        }
    }
}