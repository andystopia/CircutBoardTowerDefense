namespace ActiveOrInactiveStateManagement
{
    public interface IExclusiveStateManagerData<out T> where T : IActiveOrInactiveState
    {
        /// <summary>
        ///     Returns the active item.
        /// </summary>
        /// <returns></returns>
        public T GetActive();
    }


    public interface IExclusiveStateManager<T> : IExclusiveStateManagerData<T>, IActiveStateManager<T>
        where T : IActiveOrInactiveState
    {
    }
}