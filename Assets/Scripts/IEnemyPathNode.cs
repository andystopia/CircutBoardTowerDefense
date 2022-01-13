/// <summary>
///     Represents a single node on the enemy path.
/// </summary>
public interface IEnemyPathNode
{
    /// <summary>
    ///     The grid location of this specific path
    ///     node.
    /// </summary>
    GridLocation Location { get; }

    /// <summary>
    ///     Incoming connection to this node.
    /// </summary>
    CardinalDirection? IncomingDirection { get; }

    /// <summary>
    ///     Outgoing connection to this node.s
    /// </summary>
    CardinalDirection? OutgoingDirection { get; }
}