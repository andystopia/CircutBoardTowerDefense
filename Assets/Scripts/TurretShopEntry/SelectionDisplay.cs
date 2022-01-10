using UnityEditor;
using UnityEngine;

namespace TurretShopEntry
{
    public class SelectionDisplay : MonoBehaviour, ISelectionDisplay
    {
        [SerializeField] private GameObject litDisplay;
        [SerializeField] private GameObject unlitDisplay;

        public TurretShopEntryRoot Root { get; private set; }

        protected virtual void Awake()
        {
            Root = GetComponent<TurretShopEntryRoot>();
        }
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