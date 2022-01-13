using UnityEngine;

public class GridPositionPrefabMonoBehaviour : MonoBehaviour, IPrefabGridPositionedItem
{
    private GridLocation location;


    public GridLocation GetLocation()
    {
        return location;
    }

    public void SetLocation(GridLocation location)
    {
        this.location = location;
    }
}