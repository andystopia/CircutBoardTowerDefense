using System.Diagnostics;
/// <summary>
/// Represents the abstract concept of a location.
/// </summary>
/// <typeparam name="T"></typeparam>
[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public readonly struct Location<T>
{
    public readonly T row;
    public readonly T column;

    public Location(T row, T column)
    {
        this.row = row;
        this.column = column;
    }

    public static Location<int> MakeFromCardinalDirection(CardinalDirection dir)
    {
        return dir switch
        {
            CardinalDirection.North => new Location<int>(1, 0),
            CardinalDirection.South => new Location<int>(-1, 0),
            CardinalDirection.East => new Location<int>(0, 1),
            CardinalDirection.West => new Location<int>(0, -1),
            _ => new Location<int>(),
        };
    }
    
    public static Location<int> Add(Location<int> a, Location<int> b)
    {
        return new Location<int>(a.row + b.row, a.column + b.column);
    }

    public override string ToString()
    {
        return $"({row}, {column})";
    }
    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}