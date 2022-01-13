using UnityEngine;

namespace TurretShopEntry
{
    public class SelectionDisplay : MonoBehaviour, ISelectionDisplay
    {
        [SerializeField] private GameObject litDisplay;
        [SerializeField] private GameObject unlitDisplay;

        protected virtual void Awake()
        {
            Root = GetComponent<TurretShopEntryRoot>();
        }

        public TurretShopEntryRoot Root { get; private set; }

        public virtual void OnSelected()
        {
            litDisplay.SetActive(true);
            unlitDisplay.SetActive(false);
        }

        public virtual void OnDeselected()
        {
            litDisplay.SetActive(false);
            unlitDisplay.SetActive(true);
        }
    }
}