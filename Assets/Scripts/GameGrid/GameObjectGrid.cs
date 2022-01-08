using System.Collections.Generic;
using UnityEngine;

namespace GameGrid
{
    /// <summary>
    /// An abstraction of a grid of game objects
    /// hopefully will solve a lot of the confusing
    /// aspects of indexing, and just provide a little
    /// more of an egronomic interfacing method for
    /// dealing with grids of objects.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GameObjectGrid<T>
    {
        public Dimensions<int> Dimensions { get; }
        private readonly T[,] gridItems;

        /// <summary>
        /// Constructs a null filled game object grid with a given
        /// dimensions.
        /// </summary>
        /// <param name="dimensions"></param>
        public GameObjectGrid(Dimensions<int> dimensions)
        {
            // cols, rows.
            gridItems = new T[dimensions.width, dimensions.height];
            Dimensions = dimensions;
        }

        /// <summary>
        /// Creates a new game object grid with a given grid items array.
        /// </summary>
        /// <param name="gridItems"></param>
        public GameObjectGrid(T[,] gridItems)
        {
            // not sure whether the below line is correct, but I hope it is.
            Dimensions = new Dimensions<int>(gridItems.GetLength(0), gridItems.GetLength(1));
            this.gridItems = gridItems;
        }

        /// <summary>
        /// Will generate a valid location that is
        /// within the board. However, there
        /// might not be a tile at that location.
        /// </summary>
        /// <returns></returns>
        public GridLocation GetRandomLocation()
        {
            return new GridLocation(Random.Range(0, Dimensions.height), Random.Range(0, Dimensions.height));
        }
    
    
        /// <summary>
        /// Returns true if a passed location is inbounds
        /// otherwise it returns false.
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool IsLocationValid(GridLocation location)
        {
            return location.row < Dimensions.height && location.row >= 0 && location.column < Dimensions.width && location.column >= 0;
        }

        /// <summary>
        /// Creates an enumerator over every single
        /// space on this grid in row major fashion.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GridLocation> RowMajorIEnumerator()
        {
            var dimensions = Dimensions;
            for (int row = 0; row < dimensions.height; row++)
            {
                for (int col = 0; col < dimensions.width; col++)
                {
                    yield return new GridLocation(row, col);
                }
            }
        }
    
        /// <summary>
        /// Creates an enumerator over every single
        /// space on this grid in a column major
        /// fashion.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<GridLocation> ColumnMajorIEnumerator()
        {
            var dimensions = Dimensions;
            for (var col = 0; col < dimensions.width; col++)
            {
                for (var row = 0; row < dimensions.height; row++)
                {
                    yield return new GridLocation(row, col);
                }
            }
        }
    
        /// <summary>
        /// Generates a random tile
        /// </summary>
        /// <returns></returns>
        public T GetRandomNonNullGridItem()
        {
            T tile;
            do
            {
                tile = this[GetRandomLocation()];
            } while (tile == null);

            return tile;
        }
    
        /// <summary>
        /// Indexes this data structure using a location.
        /// </summary>
        /// <param name="location"></param>
        public T this[GridLocation location]
        {
            get => gridItems[location.column, location.row];
            set => gridItems[location.column, location.row] = value;
        }
    }
}