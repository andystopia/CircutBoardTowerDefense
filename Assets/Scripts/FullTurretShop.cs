using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using ActiveOrInactiveStateManagement;

public class FullTurretShop : BasicTogglableExclusiveStateManager<ITurretShopEntryBehavior>
{
    /// <summary>
    /// The default turret in the shop
    /// that should be selected, should
    /// probably be null/None.
    /// </summary>
    [SerializeField] private OldTurretShopEntry defaultTurretShopEntry;
    
    // Use this for initialization
    void Start()
    {
        Activate(defaultTurretShopEntry);
    }

    
}
