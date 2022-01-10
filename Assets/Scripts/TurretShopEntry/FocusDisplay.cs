using ActiveOrInactiveStateManagement;
using UnityEngine;

namespace TurretShopEntry
{
    public class TranslatedFocusable : IFocusable
    {
        private readonly IFocusable underlying;
        private readonly Vector3 translation;

        public TranslatedFocusable(IFocusable underlying, Vector3 translation)
        {
            this.underlying = underlying;
            this.translation = translation;
        }

        public void OnActivate()
        {
            underlying.OnActivate();
        }

        public void OnInactivate()
        {
            underlying.OnInactivate();
        }
    

        public Bounds FocusBounds
        {
            get
            {
                // apply translation.
                var bounds = underlying.FocusBounds;
                bounds.center = translation;
                return bounds;
            }
        }
    }


    public class FocusDisplay : MonoBehaviour, IFocusDisplay
    {
        [SerializeField] private FocusIndicator focus;
        private TurretShopEntryRoot entry;
        private RecursiveRendererBoundsFocusable focusBounds;

        private IFocusable shifted;
        protected virtual void Start()
        {
            entry = GetComponent<TurretShopEntryRoot>();
            focusBounds = GetComponent<RecursiveRendererBoundsFocusable>();
            shifted = focusBounds;
        }
    
        public TurretShopEntryRoot GetEntry()
        {
            return entry;
        }

        public Vector3 GetOriginalFocusCenter()
        {
            return focusBounds.FocusBounds.center;
        }
    
        public void SetFocusCenter(Vector3 location)
        {
            shifted = new TranslatedFocusable(focusBounds, location);
        }

        public void Show()
        {
            focus.FocusOn(shifted);
        }
    

        public void Hide()
        {
            focus.StopFocusOn(shifted);
        }
    }
}