using System.Collections.Generic;
using ActiveOrInactiveStateManagement;

namespace PrimitiveFocus
{
    public class InclusiveChildFocusManager : BasicInclusiveStateManager<IFocusable>, IFocusableRegion
    {
        private ICollection<IFocusable> possibleFocusableObjects;

        protected virtual void GetFocusableObjects()
        {
            possibleFocusableObjects = GetComponentsInChildren<IFocusable>();
        }


        
        #region IFocusableRegionMethods
        public virtual void OnActivate()
        {
            
        }

        public virtual void OnInactivate()
        {
        }
        #endregion
    }
}