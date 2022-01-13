using TurretBehaviour;
using UnityEngine;

namespace TurretShopEntry
{
    public class TurretShopEntryRoot : MonoBehaviour
    {
        [SerializeField] private Turret turret;
        public IFocusInteractor FocusInteractor { get; private set; }

        public IFocusDisplay FocusDisplay { get; private set; }

        public ISelectionInteractor SelectionInteractor { get; private set; }

        public ISelectionDisplay SelectionDisplay { get; private set; }

        public Turret Turret => turret;


        // Start is called before the first frame update

        private void Awake()
        {
            FocusInteractor = GetComponent<IFocusInteractor>();
            FocusDisplay = GetComponent<IFocusDisplay>();
            SelectionInteractor = GetComponent<ISelectionInteractor>();
            SelectionDisplay = GetComponent<ISelectionDisplay>();
        }
    }
}