using ActiveOrInactiveStateManagement;

namespace PrimitiveFocus
{
    public interface IFocusInteractor : IActiveOrInactiveState
    {
        IActiveStateManager<IFocusInteractor> GetManager();
    }
}