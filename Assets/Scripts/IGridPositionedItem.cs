
public interface IGridPositionedItem
{
    public Location<int> GetLocation();
}

public interface IPrefabGridPositionedItem : IGridPositionedItem
{
    public void SetLocation(Location<int> location);
}