using PrimitiveFocus;

namespace TurretShopEntry
{
    public class FocusInteractor : ExclusiveFocusInteractor, IFocusInteractor
    {
        private IFocusDisplay display;

        public TurretShopEntryRoot Root { get; private set; }


        private void Awake()
        {
            display = GetComponent<IFocusDisplay>();
            Root = GetComponent<TurretShopEntryRoot>();
        }

        public IFocusDisplay GetFocusDisplay()
        {
            return display;
        }

        public override void OnActivate()
        {
            display.Show();
            base.OnActivate();
        }

        public override void OnInactivate()
        {
            display.Hide();
            base.OnInactivate();
        }

        protected virtual void OnMouseEnter()
        {
            GetManager().Activate(this);
        }

        protected virtual void OnMouseExit()
        {
            GetManager().InactivateIfActive(this);
        }
    }
}
