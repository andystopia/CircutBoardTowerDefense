using System;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Represents the abstract concept of a location.
/// </summary>
[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
[Serializable]
public struct GridLocation
{
    // the following fields cannot
    // be made readonly. It doesn't
    // understand that unity cares 
    // about readonly
    [SerializeField]
    private int row;
    [SerializeField]
    private int column;

    public readonly int Row => row;
    public readonly int Column => column;
    
    

    public GridLocation(int row, int column)
    {
        this.row = row;
        this.column = column;
    }

    public static GridLocation MakeFromCardinalDirection(CardinalDirection dir)
    {
        return dir switch
        {
            CardinalDirection.North => new GridLocation(1, 0),
            CardinalDirection.South => new GridLocation(-1, 0),
            CardinalDirection.East => new GridLocation(0, 1),
            CardinalDirection.West => new GridLocation(0, -1),
            _ => new GridLocation(),
        };
    }
    
    public static GridLocation Add(GridLocation a, GridLocation b)
    {
        return new GridLocation(a.row + b.row, a.column + b.column);
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