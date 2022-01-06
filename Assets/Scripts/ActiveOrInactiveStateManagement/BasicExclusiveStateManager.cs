using UnityEngine;

namespace ActiveOrInactiveStateManagement
{
    public class BasicExclusiveStateManager<T> : MonoBehaviour,  IExclusiveStateManager<T> where T : class, IActiveOrInactiveState
    {
        /// <summary>
        /// The currently selected turret shop.
        /// This variable should probably only
        /// be accessed by it's nonCamelCase
        /// variant.
        /// </summary>
        private T selected;

        /// <summary>
        /// Gets the active element.
        /// </summary>
        /// <returns></returns>
        public virtual T GetActive()
        {
            return selected;
        }

        /// <summary>
        /// Inactivate the current object if it's not already inactive.
        /// </summary>
        /// <param name="item"></param>
        public virtual void InactivateIfActive(T item)
        {
            if (IsActive(item))
            {
                Activate(null);
            }
        }

        /// <summary>
        /// Sets the active item in the shop.
        ///
        /// If the item parameter is null, then
        /// there will be no active shop at the
        /// end of this method.
        /// </summary>
        /// <param name="item"></param>
        public virtual void Activate(T item)
        {
            // guard: if we're already the active object, then exit.
            if (IsActive(item)) return;

            // disable the current shop
            selected?.OnInactivate();

            // activate the passed item
            selected = item;
            // send activated notification the passed item.
            item?.OnActivate();
        }

        public virtual bool IsActive(T item)
        {
            return item == GetActive();
        }

        /// <summary>
        /// Disables any active element
        /// </summary>
        public virtual void InactivateAll()
        {
            Activate(null);
        }
    }
}