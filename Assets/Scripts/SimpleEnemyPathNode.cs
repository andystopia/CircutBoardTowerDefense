public class SimpleEnemyPathNode : IEnemyPathNode
{
    public SimpleEnemyPathNode(GridLocation location, CardinalDirection? incomingDirection,
        CardinalDirection? outgoingDirection)
    {
        Location = location;
        IncomingDirection = incomingDirection;
        OutgoingDirection = outgoingDirection;
    }

    public GridLocation Location { get; }
    public CardinalDirection? IncomingDirection { get; }
    public CardinalDirection? OutgoingDirection { get; }
}