namespace ActiveOrInactiveStateManagement
{
    public interface IActiveOrInactiveState
    {
        /// <summary>
        ///     Sets the current object to active.
        /// </summary>
        public void OnActivate();

        /// <summary>
        ///     Sets the current object to disabled.
        /// </summary>
        public void OnInactivate();
    }
}