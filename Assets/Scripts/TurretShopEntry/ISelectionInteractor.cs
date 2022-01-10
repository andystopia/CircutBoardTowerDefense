using ActiveOrInactiveStateManagement;

namespace TurretShopEntry
{
    public interface ISelectionInteractor : IActiveOrInactiveState, IOldTurretShopBehavior
    {
        TurretShopEntryRoot Root { get;  }
    }
}