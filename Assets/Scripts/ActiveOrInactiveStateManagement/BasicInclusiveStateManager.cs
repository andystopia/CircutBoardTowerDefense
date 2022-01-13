using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace ActiveOrInactiveStateManagement
{
    public class BasicInclusiveStateManager<T> : MonoBehaviour, IInclusiveStateManager<T>
        where T : class, IActiveOrInactiveState
    {
        protected ICollection<T> currentlyActive;

        public ICollection<T> GetActive()
        {
            return currentlyActive;
        }

        public void SetActive(T item)
        {
            if (item == null) return;
            currentlyActive.Add(item);
        }

        public void InactivateAll()
        {
            currentlyActive = new Collection<T>();
        }

        public bool IsActive(T item)
        {
            return currentlyActive.Contains(item);
        }
    }
}