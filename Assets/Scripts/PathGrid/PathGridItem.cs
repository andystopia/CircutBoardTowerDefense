using UnityEngine;

namespace PathGrid
{
    public class PathGridItem : MonoBehaviour
    {
        [SerializeField] private GameObject north;
        [SerializeField] private GameObject south;
        [SerializeField] private GameObject east;
        [SerializeField] private GameObject west;

        public void Enable(CardinalDirection direction)
        {
            var go = direction switch
            {
                CardinalDirection.North => north,
                CardinalDirection.East => east,
                CardinalDirection.South => south,
                CardinalDirection.West => west,
                _ => null
            };

            if (go != null) go.SetActive(true);
        }
    }
}