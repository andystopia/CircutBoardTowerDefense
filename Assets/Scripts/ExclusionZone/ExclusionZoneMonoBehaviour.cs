using UnityEngine;

namespace ExclusionZone
{
    public abstract class ExclusionZoneMonoBehaviour : MonoBehaviour, IExclusionZone
    {
        private IExclusionZone zone;

        protected IExclusionZone Zone
        {
            get => zone;
            set => zone = value;
        }
        
        
        public virtual bool IsInZone(GridLocation loc)
        {
            return Zone.IsInZone(loc);
        }
    }
    
}