namespace ActiveOrInactiveStateManagement
{
    public interface ISingleItemActiveStateManager<T> where T : IActiveOrInactiveState
    {
        T GetActive();
    }
}