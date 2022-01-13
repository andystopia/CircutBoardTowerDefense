using System;

public static class CardinalDirectionExtensions
{
    public static CardinalDirection Opposite(this CardinalDirection direction)
    {
        return direction switch
        {
            CardinalDirection.North => CardinalDirection.South,
            CardinalDirection.South => CardinalDirection.North,
            CardinalDirection.East => CardinalDirection.West,
            CardinalDirection.West => CardinalDirection.East,
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }

    public static GridLocation GetGridLocationSign(this CardinalDirection direction)
    {
        return direction switch
        {
            CardinalDirection.North => GridLocation.North,
            CardinalDirection.South => GridLocation.South,
            CardinalDirection.East => GridLocation.East,
            CardinalDirection.West => GridLocation.West,
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }
}