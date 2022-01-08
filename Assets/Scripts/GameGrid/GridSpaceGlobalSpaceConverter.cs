using UnityEngine;

namespace GameGrid
{
    /// <summary>
    /// Converts a place on the grid
    /// into a global space.
    /// </summary>
    public static class GridSpaceGlobalSpaceConverter
    {
        private const float offsetX = -15;
        private const float offsetZ = -9f;

        /// <summary>
        /// Converts a location (row, col) into
        /// a global location.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="yOffset"></param>
        /// <returns></returns>
        public static Vector3 FromLocation(Location<int> location, float yOffset = 0.0f)
        {
            return new Vector3((1.5f * location.column + offsetX), yOffset, (1.5f * location.row + offsetZ));
        }
    }
}