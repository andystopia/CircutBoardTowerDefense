using UnityEngine;

namespace DefaultNamespace
{
    public class EditorGridPositionedObjectMonoBehaviour : MonoBehaviour, IGridPositionedItem
    {
        [SerializeField]
        private int row;

        [SerializeField] 
        private int column;

        private Location<int>? location; 
        
        public Location<int> GetLocation()
        {
            location ??= new Location<int>(row, column);
            return location.Value;
        }
    }
}