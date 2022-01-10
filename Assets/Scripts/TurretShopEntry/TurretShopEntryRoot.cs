using ActiveOrInactiveStateManagement;
using TMPro;
using TurretBehaviour;
using UnityEngine;

namespace TurretShopEntry
{
    public class TurretShopEntryRoot : MonoBehaviour
    {
        public IFocusInteractor FocusInteractor { get; private set; }

        public IFocusDisplay FocusDisplay { get; private set; }

        public ISelectionInteractor SelectionInteractor { get; private set; }

        public ISelectionDisplay SelectionDisplay { get; private set; }


        [SerializeField] private Turret turret;
        
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
