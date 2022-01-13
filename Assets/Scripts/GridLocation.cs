using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>
/// Represents the abstract concept of a location.
/// </summary>
[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
[Serializable]
public struct GridLocation : IEquatable<GridLocation>
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

    public static readonly GridLocation North = new GridLocation(1, 0);
    public static readonly GridLocation South = new GridLocation(-1, 0);
    public static readonly GridLocation East = new GridLocation(0, 1);
    public static readonly GridLocation West = new GridLocation(0, -1);
    public static readonly GridLocation Zero = new GridLocation(0, 0);
    

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

    public static GridLocation Scale(GridLocation a, GridLocation b)
    {
        return new GridLocation(a.row * b.row, a.column * b.column);
    }

    public static GridLocation Scale(GridLocation value, int scalar)
    {
        return new GridLocation(value.row * scalar, value.column * scalar);
    }
    public override string ToString()
    {
        return $"({row}, {column})";
    }
    private string GetDebuggerDisplay()
    {
        return ToString();
    }
    
    public bool Equals(GridLocation other)
    {
        return row == other.row && column == other.column;
    }

    public override bool Equals(object obj)
    {
        return obj is GridLocation other && Equals(other);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return (row * 397) ^ column;
        }
    }
}