namespace ActiveOrInactiveStateManagement
{
    public interface IActiveStateManager<T> where T : IActiveOrInactiveState
    {
        void Activate(T item);
        void InactivateIfActive(T item);

        void InactivateAll();
        bool IsActive(T item);
    }
}