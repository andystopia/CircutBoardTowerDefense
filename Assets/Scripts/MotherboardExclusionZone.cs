using ExclusionZone;
using UnityEngine;

public class MotherboardExclusionZone : ExclusionZoneMonoBehaviour
{
    private const int horizontalWidth = 4;
    private const int verticalWidth = 1;

    private Motherboard spawnManager;

    public override bool IsInZone(GridLocation loc)
    {
        if (spawnManager == null)
        {
            spawnManager = GetComponent<Motherboard>();
            spawnManager.UpdateExclusionZone();
        }
        return base.IsInZone(loc);
    }

    public void SetDirection(GridLocation spawnLocation, CardinalDirection direction)
    {
        if (direction == CardinalDirection.North || direction == CardinalDirection.South)
        {
            Zone = new RectangleExclusionZone(
                new GridLocation(spawnLocation.Row - verticalWidth / 2, spawnLocation.Column - horizontalWidth / 2),
                new GridLocation(spawnLocation.Row + verticalWidth / 2, spawnLocation.Column + horizontalWidth + 2));
        }
        else
        {
            Zone = new RectangleExclusionZone(
                new GridLocation(spawnLocation.Row - horizontalWidth / 2, spawnLocation.Column - verticalWidth / 2),
                new GridLocation(spawnLocation.Row + horizontalWidth / 2, spawnLocation.Column + verticalWidth / 2)
            );
        }
    }
}