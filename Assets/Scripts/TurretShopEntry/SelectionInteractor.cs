using ActiveOrInactiveStateManagement;
using TurretBehaviour;
using UnityEngine;

namespace TurretShopEntry
{
    public class SelectionInteractor : MonoBehaviour, ISelectionInteractor
    {
        [SerializeField] private TurretShopSelectionManager manager;
        private TurretShopEntryRoot root;
        private ISelectionDisplay selectionDisplay;

        public TurretShopEntryRoot Root => root;

        public Turret AssociatedTurretPrefab()
        {
            return root.Turret;
        }

        public float GetEnergyCost()
        {
            return root.Turret.EnergyCost;
        }

        protected virtual void Awake()
        {
            root = GetComponent<TurretShopEntryRoot>();
            selectionDisplay = GetComponent<ISelectionDisplay>();
        }

        protected virtual void OnMouseDown()
        {
            manager.Activate(this);
        }
        
        public void OnActivate()
        {
            selectionDisplay.OnSelected();
        }

        public void OnInactivate()
        {
            selectionDisplay.OnDeselected();
        }
    }
}