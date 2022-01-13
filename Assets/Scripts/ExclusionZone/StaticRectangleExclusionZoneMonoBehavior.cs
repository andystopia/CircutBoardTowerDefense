using UnityEngine;

namespace ExclusionZone
{
    public class StaticRectangleExclusionZoneMonoBehavior : ExclusionZoneMonoBehaviour
    {
        [SerializeField] private GridLocation startLocation;
        [SerializeField] private GridLocation endLocation;


        public void Awake()
        {
            Zone = new RectangleExclusionZone(startLocation, endLocation);
        }
    }
}