namespace ActiveOrInactiveStateManagement
{
    public interface IExclusiveStateManager<T> : IActiveStateManager<T> where T : IActiveOrInactiveState
    {
        /// <summary>
        /// Returns the active item.
        /// </summary>
        /// <returns></returns>
        public T GetActive();
    }
}