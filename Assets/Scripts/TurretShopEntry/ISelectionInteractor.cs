using ActiveOrInactiveStateManagement;

namespace TurretShopEntry
{
    public interface ISelectionInteractor : IActiveOrInactiveState, ITurretShopEntryBehavior
    {
        TurretShopEntryRoot Root { get; }
    }
}