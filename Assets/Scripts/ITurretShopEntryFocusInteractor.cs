using ActiveOrInactiveStateManagement;
using PrimitiveFocus;

public interface ITurretShopEntryFocusInteractor : IExclusiveFocusInteractor
{
    ITurretShopEntryFocusDisplay GetFocusDisplay();
}