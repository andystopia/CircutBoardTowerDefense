using System;

namespace Helpers
{
    public class GridLocationTransform
    {
        /// <summary>
        /// Offset a location by a given cardinal direction
        /// by a passed number of units.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="direction"></param>
        /// <param name="units"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static GridLocation ByCardinalDirection(GridLocation location, CardinalDirection direction,
            int units = 1)
        {
            return direction switch
            {
                CardinalDirection.North => new GridLocation(location.Row - units, location.Column),
                CardinalDirection.South => new GridLocation(location.Row + units, location.Column),
                CardinalDirection.East => new GridLocation(location.Row, location.Column + units),
                CardinalDirection.West => new GridLocation(location.Row, location.Column - units),
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
        }
    }
}