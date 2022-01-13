using System.IO;
using JetBrains.Annotations;
using UnityEngine.UI;

public class SimpleEnemyPathNode : IEnemyPathNode
{
    public GridLocation Location { get; }
    public CardinalDirection? IncomingDirection { get; }
    public CardinalDirection? OutgoingDirection { get; }

    public SimpleEnemyPathNode(GridLocation location, CardinalDirection? incomingDirection, CardinalDirection? outgoingDirection)
    {
        Location = location;
        IncomingDirection = incomingDirection;
        OutgoingDirection = outgoingDirection;
    }
}