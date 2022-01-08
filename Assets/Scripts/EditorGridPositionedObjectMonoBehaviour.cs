using UnityEngine;

namespace DefaultNamespace
{
    public class EditorGridPositionedObjectMonoBehaviour : MonoBehaviour, IGridPositionedItem
    {
        [SerializeField]
        private int row;

        [SerializeField] 
        private int column;

        private GridLocation? location; 
        
        public GridLocation GetLocation()
        {
            location ??= new GridLocation(row, column);
            return location.Value;
        }
    }
}