using ActiveOrInactiveStateManagement;
using PrimitiveFocus;
using Tile;
using TurretShopEntry;
using IFocusInteractor = PrimitiveFocus.IFocusInteractor;

public interface ITileSelectionInteractor : IActiveOrInactiveState
{
    public Tile.Tile Root { get; }

    public void Init(EnergyCounter energyCounter, IExclusiveStateManagerData<ISelectionInteractor> turretShop,
        BasicExclusiveStateManager<ITileSelectionInteractor> tileSelectionManager,
        ExclusiveSubsectionFocusManager focusManager);

    void Hovered();
    void UnHovered();
    void AttemptToPlaceTurret();
    void SellTurret();

    IGridPositionedItem GetGridPositionedComponent();
    IFocusInteractor GetFocusInteractor();
    (FilledState, TurretShopSelectionStatus) GetState();
}