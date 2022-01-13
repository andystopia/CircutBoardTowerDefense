using UnityEngine;

namespace ExclusionZone
{
    public abstract class ExclusionZoneMonoBehaviour : MonoBehaviour, IExclusionZone
    {
        protected IExclusionZone Zone { get; set; }


        public virtual bool IsInZone(GridLocation loc)
        {
            return Zone.IsInZone(loc);
        }
    }
}