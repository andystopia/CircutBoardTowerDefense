/// <summary>
/// this is a rectangle exclusion zone
/// which basically just defines
/// a rectangle shaped area where
/// we cannot place any objects.
/// </summary>
public readonly struct RectangleExclusionZone : IExclusionZone
{
    public readonly Location<int> location1;
    public readonly Location<int> location2;

    /// <summary>
    /// Defines a rectangle by two corner points
    /// which will be in our exclusion. Order doesn't matter.
    /// </summary>
    /// <param name="location1"></param>
    /// <param name="location2"></param>
    public RectangleExclusionZone(Location<int> location1, Location<int> location2)
    {
        this.location1 = location1;
        this.location2 = location2;
    }

    /// <summary>
    /// Calculate if two numbers bound another number
    /// returns true if b is numerically between a and c.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <returns></returns>
    private static bool IsSandwiched(int a, int b, int c)
    {
        return (a <= b && b <= c) || (c <= b && b <= a);
    }

    /// <summary>
    /// Returns true if we cannot place
    /// a  tile, or false if we can place a tile.
    /// </summary>
    /// <param name="loc"></param>
    /// <returns>true if it is in the zone, else false</returns>
    public bool IsInZone(Location<int> loc)
    {
        return IsSandwiched(location1.column, loc.column, location2.column) &&
               IsSandwiched(location1.row, loc.row, location2.row);
    }
}