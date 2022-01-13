using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

[Serializable]
public struct RelativePathNode
{
    [SerializeField] private int distance;
    [SerializeField] private CardinalDirection direction;

    public int Distance => distance;
    public CardinalDirection Direction => direction;

    public override string ToString()
    {
        return $"Distance: {Distance}, Direction: {Direction}";
    }
}
[CreateAssetMenu(fileName = "Enemy Path Relative", menuName = "Enemy Path/Relative Path")]
public class EnemyPathRelative : EnemyPathBase
{
    [SerializeField] private GridLocation startingLocation;
    [SerializeField] private List<RelativePathNode> pathNodes;

    
    public static GridLocation OffsetGridLocationWithPathNode(GridLocation location, RelativePathNode relativePathNode)
    {
        var (colOffset, rowOffset) = relativePathNode.Direction switch
        {
            CardinalDirection.North => (0, 1),
            CardinalDirection.South => (0, -1),
            CardinalDirection.East => (1, 0),
            CardinalDirection.West => (-1, 0),
            _ => throw new ArgumentOutOfRangeException()
        };

        return new GridLocation(location.Row + relativePathNode.Distance * rowOffset,
            location.Column + relativePathNode.Distance * colOffset);
    }

    /// <summary>
    /// Gets the extrapolator for all the points in this
    /// structure. 
    /// </summary>
    /// <returns></returns>
    public override IEnemyPathIntermediateValueExtrapolator GetExtrapolator()
    {
        return new RelativeEnemyPathIntermediateValueExtrapolator(startingLocation, pathNodes);
    }
}