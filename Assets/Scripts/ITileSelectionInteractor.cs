using ActiveOrInactiveStateManagement;
using PrimitiveFocus;
using Tile;

public interface ITileSelectionInteractor : IActiveOrInactiveState
{
    public void Init(EnergyCounter energyCounter, BasicExclusiveStateManager<IOldTurretShopBehavior> turretShop,
        BasicExclusiveStateManager<ITileSelectionInteractor> tileSelectionManager, ExclusiveSubsectionFocusManager focusManager);
    void Hovered();
    void UnHovered();
    void AttemptToPlaceTurret();

    IGridPositionedItem GetGridPositionedComponent();
    IFocusInteractor GetFocusInteractor();
    (FilledState, TurretShopSelectionStatus) GetState();
}