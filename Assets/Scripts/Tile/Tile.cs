using UnityEngine;

namespace Tile
{
    /// <summary>
    /// just the root class to hold onto,
    /// essentially a pointer which we
    /// can derive the other components from.
    ///
    /// Only should be used to initialize the prefab.
    /// </summary>
    public class Tile : MonoBehaviour
    {
        private ITileSelectionInteractor selectionInteraction;
        private ITileExclusiveFocusInteractor focusInteractor;
    
        private void Awake()
        {
            selectionInteraction = GetComponent<ITileSelectionInteractor>();
            focusInteractor = GetComponent<ITileExclusiveFocusInteractor>();
        }
    
        /// <summary>
        /// Returns the TileSelectionInteractor.
        /// This is primarily used for stating whether
        /// or not the tile is "selected", although
        /// that definition is loose and subject to change.
        /// </summary>
        public ITileSelectionInteractor GetSelectionInteractor()
        {
            return selectionInteraction;
        }

        public ITileExclusiveFocusInteractor GetFocusInteractor()
        {
            return focusInteractor;
        }
    }
}
