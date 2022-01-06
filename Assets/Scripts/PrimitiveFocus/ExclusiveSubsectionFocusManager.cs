using System.Collections.Generic;
using ActiveOrInactiveStateManagement;
using UnityEngine;

namespace PrimitiveFocus
{
    /// <summary>
    /// This class is essentially
    /// a way to communicate from the focused events
    /// to an observer pattern which
    /// focus displays can hook into.
    /// </summary>
    public class ExclusiveSubsectionFocusManager : BasicExclusiveStateManager<IFocusInteractor>, IFocusableRegion
    {
        #region IFocusableRegionEmptyMethods
        public virtual void OnActivate()
        {
            
        }

        public virtual void OnInactivate()
        {
        }
        
        #endregion
    }
}