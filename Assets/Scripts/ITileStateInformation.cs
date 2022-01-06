
using ActiveOrInactiveStateManagement;

public interface ITileStateInformation
{
    void WithState(EnergyCounter energy, BasicExclusiveStateManager<ITileSelectionInteraction> tileSelectionManager,
        BasicExclusiveStateManager<IOldTurretShopBehavior> turretShopManager);
}

/// <summary>
/// Components that are not attached to Tile
/// should NEVER request to interact with this
/// interface, but it's fine if they do, because
/// they supplied the interface that is tied
/// to this interface's data.
/// </summary>
public interface ITileStateInternalInformation
{
    public EnergyCounter getEnergy();
    public BasicExclusiveStateManager<ITileSelectionInteraction> GetTileSelectionManager();
    public BasicExclusiveStateManager<IOldTurretShopBehavior> TurretShopManager();
}