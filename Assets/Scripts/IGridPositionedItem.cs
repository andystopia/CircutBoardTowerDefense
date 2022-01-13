public interface IGridPositionedItem
{
    public GridLocation GetLocation();
}

public interface IPrefabGridPositionedItem : IGridPositionedItem
{
    public void SetLocation(GridLocation location);
}