using ActiveOrInactiveStateManagement;
using TurretBehaviour;

public interface ITurretShopEntryBehavior : IActiveOrInactiveState
{
    Turret AssociatedTurretPrefab();
    float GetEnergyCost();
}