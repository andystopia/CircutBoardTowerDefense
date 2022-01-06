using System.Collections;
using System.Collections.Generic;
using ActiveOrInactiveStateManagement;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EnergyCounter energyCounter;
    [SerializeField] private Tile tilePrefab;

    private ITileSelectionInteraction tileSelectionInteraction;
    
    public BasicExclusiveStateManager<IOldTurretShopBehavior> turretShop;
    [FormerlySerializedAs("tileManager")] public TileSelectionManager tileSelectionManager;

    public bool gameOver;
    public bool inTileMenu = false;


    public FocusIndicator focus;
    // Start is called before the first frame update
    void Start()
    {
        tileSelectionInteraction = tilePrefab.GetComponent<ITileSelectionInteraction>();
    }

    public EnergyCounter GetEnergyCounter()
    {
        return energyCounter;
    }

    public BasicExclusiveStateManager<IOldTurretShopBehavior> GetTurretShop()
    {
        return turretShop;
    }

}
