using ActiveOrInactiveStateManagement;
using TurretShopEntry;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EnergyCounter energyCounter;
    [SerializeField] private Tile.Tile tilePrefab;

    public TurretShopSelectionManager turretShop;
    [FormerlySerializedAs("tileManager")] public TileSelectionManager tileSelectionManager;

    public FocusIndicator focus;

    private ITileSelectionInteractor tileSelectionInteraction;

    // Start is called before the first frame update
    private void Start()
    {
        tileSelectionInteraction = tilePrefab.GetComponent<ITileSelectionInteractor>();
    }

    public EnergyCounter GetEnergyCounter()
    {
        return energyCounter;
    }

    public BasicExclusiveStateManager<ISelectionInteractor> GetTurretShop()
    {
        return turretShop;
    }
}