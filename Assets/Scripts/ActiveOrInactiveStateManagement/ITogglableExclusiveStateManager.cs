namespace ActiveOrInactiveStateManagement
{
    public interface ITogglableExclusiveStateManager<T> : IExclusiveStateManager<T> where T : IActiveOrInactiveState 
    {
        /// <summary>
        /// If the passed item is active, then
        /// it is disabled, and there is no
        /// active item.
        /// </summary>
        /// <param name="item"></param>
        public void ToggleActive(T item);
    }
}