using System.Collections.Generic;

/// <summary>
///     this is essentially an adapter pattern class from
///     an enemy path class to the path drawing algorithm.
/// </summary>
public interface IEnemyPathIntermediateValueExtrapolator
{
    /// <summary>
    ///     This method returns an object for every tile
    ///     that this path intersects with.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<IEnemyPathNode> GetIntermediateValues();

    /// <summary>
    ///     This method returns only the points at which the
    ///     path changes directions.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<IEnemyPathNode> GetMinimalRepresentation();
}