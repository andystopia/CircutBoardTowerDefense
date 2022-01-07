using ActiveOrInactiveStateManagement;
using PrimitiveFocus;

public interface ITileSelectionInteraction : IActiveOrInactiveState
{
    public void Init(EnergyCounter energyCounter, BasicExclusiveStateManager<IOldTurretShopBehavior> turretShop,
        BasicExclusiveStateManager<ITileSelectionInteraction> tileSelectionManager, ExclusiveSubsectionFocusManager focusManager);
    void Hovered();
    void UnHovered();
    void AttemptToPlaceTurret();

    IGridPositionedItem GetGridPositionedComponent();
    IFocusInteractor GetFocusInteractor();
}