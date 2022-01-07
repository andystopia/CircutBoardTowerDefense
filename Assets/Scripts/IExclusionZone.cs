/// <summary>
/// This defines an interface which
/// allows us to determine
/// whether or not a given
/// square can have a tile placed
/// on it.
/// </summary>
public interface IExclusionZone
{
    /// <summary>
    /// Returns true if we cannot place
    /// a  tile, or false if we can place a tile.
    /// </summary>
    /// <param name="loc"></param>
    /// <returns>true if it is in the zone, else false</returns>
    bool IsInZone(Location<int> loc);
}