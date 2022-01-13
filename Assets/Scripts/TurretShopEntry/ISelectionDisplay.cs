namespace TurretShopEntry
{
    public interface ISelectionDisplay
    {
        public TurretShopEntryRoot Root { get; }
        void OnSelected();
        void OnDeselected();
    }
}