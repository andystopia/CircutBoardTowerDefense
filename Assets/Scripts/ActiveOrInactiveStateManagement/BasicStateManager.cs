using UnityEngine;

namespace ActiveOrInactiveStateManagement
{
    public abstract class BasicStateManager<T> : MonoBehaviour, IActiveStateManager<T> where T : IActiveOrInactiveState
    {
        public abstract void Activate(T item);
        public abstract void InactivateIfActive(T item);
        public abstract void InactivateAll();
        public abstract bool IsActive(T item);
    }
}