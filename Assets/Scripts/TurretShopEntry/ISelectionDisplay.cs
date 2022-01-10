namespace TurretShopEntry
{
    public interface ISelectionDisplay
    {
        void OnSelected();
        void OnDeselected();

        public TurretShopEntryRoot Root { get; }
    }
}