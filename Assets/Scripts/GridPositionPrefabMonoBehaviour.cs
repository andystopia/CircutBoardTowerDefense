
using UnityEngine;

public class GridPositionPrefabMonoBehaviour : MonoBehaviour, IPrefabGridPositionedItem
{
    private Location<int> location;
    
    
    public Location<int> GetLocation()
    {
        return location;
    }

    public void SetLocation(Location<int> location)
    {
        this.location = location;
    }
}