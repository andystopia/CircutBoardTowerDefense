﻿using System.Collections;
using System.Collections.Generic;
using ActiveOrInactiveStateManagement;
using PathGrid;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EnergyCounter energyCounter;
    [SerializeField] private Tile.Tile tilePrefab;

    private ITileSelectionInteractor tileSelectionInteraction;
    
    public TurretShopSelectionManager turretShop;
    [FormerlySerializedAs("tileManager")] public TileSelectionManager tileSelectionManager;

    public FocusIndicator focus;
    // Start is called before the first frame update
    void Start()
    {
        tileSelectionInteraction = tilePrefab.GetComponent<ITileSelectionInteractor>();
    }

    public EnergyCounter GetEnergyCounter()
    {
        return energyCounter;
    }

    public BasicExclusiveStateManager<TurretShopEntry.ISelectionInteractor> GetTurretShop()
    {
        return turretShop;
    }
}
