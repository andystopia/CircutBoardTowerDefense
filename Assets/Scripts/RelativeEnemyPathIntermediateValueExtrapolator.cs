using System.Collections.Generic;

/// <summary>
///     This class essentially is able to manage
///     a bunch of relative points and change
///     them into absolute grid locations, filling
///     in all the spaces in between.
/// </summary>
public class RelativeEnemyPathIntermediateValueExtrapolator : IEnemyPathIntermediateValueExtrapolator
{
    private readonly List<RelativePathNode> pathNodes;
    private readonly GridLocation startingLocation;

    public RelativeEnemyPathIntermediateValueExtrapolator(GridLocation startingLocation,
        List<RelativePathNode> pathNodes)
    {
        this.startingLocation = startingLocation;
        this.pathNodes = pathNodes;
    }

    /// <summary>
    ///     Returns a full list of path nodes which the enemies
    ///     will have to transverse. This method will return every
    ///     single node that is on the path.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<IEnemyPathNode> GetIntermediateValues()
    {
        // still a problem though, because the entry node is still going 
        // to be calculated in the loop. 
        // return the entry node.
        var loc = startingLocation;
        CardinalDirection? lastOutgoingDirection = null;

        // this is fine, because we don't actually start
        // out with a path node, rather we start out at the 
        // starting location.
        foreach (var pathNode in pathNodes)
        {
            // cache a few variables on the stack, 
            // because they're small and could optimize lookup times.
            var outgoingDirection = pathNode.Direction;
            var oppositeOutgoingDirection = outgoingDirection.Opposite();
            var directionLocationSign = outgoingDirection.GetGridLocationSign();


            // ----- CALCULATE THE POSITION AND ATTRIBUTES OF THE TURN NODE ---- //
            yield return new SimpleEnemyPathNode(loc, lastOutgoingDirection?.Opposite(), outgoingDirection);


            // ---- CALCULATE THE NODES IN BETWEEN THIS TURN NODE AND WHAT WILL EITHER ---- //
            // ----          BE THE END OR THE NEXT NODE                               ---- //

            // remember to not calculate the turn node more than once,
            // and if we iterated all the say to distance we'd be doing that.
            // we only really want to evaluate the values *in between* 
            // the two given nodes.
            var extrapolatedLoc = loc;
            for (var i = 1; i < pathNode.Distance; i++)
            {
                extrapolatedLoc = GridLocation.Add(extrapolatedLoc, directionLocationSign);
                yield return new SimpleEnemyPathNode(extrapolatedLoc, oppositeOutgoingDirection, outgoingDirection);
            }

            // calculate the length of the upcoming path
            loc = GridLocation.Add(loc,
                GridLocation.Scale(directionLocationSign, pathNode.Distance));

            // don't forget to update the state for the next iteration.
            lastOutgoingDirection = outgoingDirection;
        }

        // var exitNodeLocation = GridLocation.Add(loc, GridLocation.Scale(lastTurnNode.Direction.GetGridLocationSign(), lastTurnNode.Distance));
        yield return new SimpleEnemyPathNode(loc, lastOutgoingDirection?.Opposite(), null);
    }

    public IEnumerable<IEnemyPathNode> GetMinimalRepresentation()
    {
        // notice how this method is very similar to the other method,
        // except this method doesn't extrapolate the extra points.


        // still a problem though, because the entry node is still going 
        // to be calculated in the loop. 
        // return the entry node.
        var loc = startingLocation;
        CardinalDirection? lastOutgoingDirection = null;

        // this is fine, because we don't actually start
        // out with a path node, rather we start out at the 
        // starting location.
        foreach (var pathNode in pathNodes)
        {
            // cache a few variables on the stack, 
            // because they're small and could optimize lookup times.
            var outgoingDirection = pathNode.Direction;
            var directionLocationSign = outgoingDirection.GetGridLocationSign();


            // ----- CALCULATE THE POSITION AND ATTRIBUTES OF THE TURN NODE ---- //
            yield return new SimpleEnemyPathNode(loc, lastOutgoingDirection?.Opposite(), outgoingDirection);

            // calculate the length of the upcoming path
            loc = GridLocation.Add(loc,
                GridLocation.Scale(directionLocationSign, pathNode.Distance));

            // don't forget to update the state for the next iteration.
            lastOutgoingDirection = outgoingDirection;
        }

        // finally we need to return the exit node.
        yield return new SimpleEnemyPathNode(loc, lastOutgoingDirection?.Opposite(), null);
    }
}