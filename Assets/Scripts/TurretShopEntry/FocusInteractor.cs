using PrimitiveFocus;

namespace TurretShopEntry
{
    public class FocusInteractor : ExclusiveFocusInteractor, IFocusInteractor
    {
        private IFocusDisplay display;


        private void Awake()
        {
            display = GetComponent<IFocusDisplay>();
            Root = GetComponent<TurretShopEntryRoot>();
        }

        protected virtual void OnMouseEnter()
        {
            GetManager().Activate(this);
        }

        protected virtual void OnMouseExit()
        {
            GetManager().InactivateIfActive(this);
        }

        public TurretShopEntryRoot Root { get; private set; }

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
    }
}