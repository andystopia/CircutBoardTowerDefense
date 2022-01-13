using TurretBehaviour;
using UnityEngine;

namespace TurretShopEntry
{
    public class SelectionInteractor : MonoBehaviour, ISelectionInteractor
    {
        [SerializeField] private TurretShopSelectionManager manager;
        private ISelectionDisplay selectionDisplay;

        protected virtual void Awake()
        {
            Root = GetComponent<TurretShopEntryRoot>();
            selectionDisplay = GetComponent<ISelectionDisplay>();
        }

        protected virtual void OnMouseDown()
        {
            manager.Activate(this);
        }

        public TurretShopEntryRoot Root { get; private set; }

        public Turret AssociatedTurretPrefab()
        {
            return Root.Turret;
        }

        public float GetEnergyCost()
        {
            return Root.Turret.EnergyCost;
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