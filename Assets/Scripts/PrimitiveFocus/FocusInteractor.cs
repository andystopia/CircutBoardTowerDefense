using ActiveOrInactiveStateManagement;
using UnityEngine;

namespace PrimitiveFocus
{
    /// <summary>
    ///     this should be rewritten to have the component
    ///     returned from an abstract getter, to avoid
    ///     conflicting IFocusable implementations.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class FocusInteractor : MonoBehaviour, IFocusInteractor
    {
        public abstract IActiveStateManager<IFocusInteractor> GetManager();

        public virtual void OnActivate()
        {
        }

        public virtual void OnInactivate()
        {
        }
    }
}