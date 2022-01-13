using System.Collections.Generic;

namespace ActiveOrInactiveStateManagement
{
    /// <summary>
    ///     Represents a collection of states
    ///     that can be either enabled or disabled
    ///     which can are
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IInclusiveStateManager<T>
    {
        /// <summary>
        ///     Returns a collection of all
        ///     the other active items.
        /// </summary>
        /// <returns></returns>
        public ICollection<T> GetActive();

        /// <summary>
        ///     Sets the active item. Calls its corresponding method.
        /// </summary>
        /// <param name="item"></param>
        public void SetActive(T item);

        /// <summary>
        ///     Returns true if the object is active.
        /// </summary>
        /// <param name="item"></param>
        public bool IsActive(T item);

        /// <summary>
        ///     Inactivates all the items.
        /// </summary>
        public void InactivateAll();
    }
}