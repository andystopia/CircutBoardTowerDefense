using PrimitiveFocus;

namespace TurretShopEntry
{
    public interface IFocusInteractor : IExclusiveFocusInteractor
    {
        IFocusDisplay GetFocusDisplay();
        TurretShopEntryRoot Root { get; }
    }
}