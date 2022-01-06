using System.Collections.Generic;
using UnityEngine;


namespace ActiveOrInactiveStateManagement
{

    public class BasicTogglableExclusiveStateManager<T> : BasicExclusiveStateManager<T>, ISingleItemActiveStateManager<T> where T : class, IActiveOrInactiveState
    {
        /// <summary>
        /// If the item is active, it deactivates it,
        /// if the item is not active, it activates it.
        /// if the item is null, then nothing happens.
        /// </summary>
        /// <param name="item"></param>
        public void ToggleActive(T item)
        {
            // doesn't really make sense to toggle a null item.
            if (item == null) return;

            Activate(ReferenceEquals(GetActive(), item) ? null : item);
        }
    }
}