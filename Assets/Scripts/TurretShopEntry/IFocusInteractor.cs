using PrimitiveFocus;

namespace TurretShopEntry
{
    public interface IFocusInteractor : IExclusiveFocusInteractor
    {
        TurretShopEntryRoot Root { get; }
        IFocusDisplay GetFocusDisplay();
    }
}