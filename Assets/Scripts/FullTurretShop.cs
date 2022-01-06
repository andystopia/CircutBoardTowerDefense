using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using ActiveOrInactiveStateManagement;

public class FullTurretShop : BasicTogglableExclusiveStateManager<IOldTurretShopBehavior>
{
    /// <summary>
    /// The default turret in the shop
    /// that should be selected, should
    /// probably be null/None.
    /// </summary>
    [SerializeField] private OldTurretShopEntry defaultOldOldTurretShopEntry;
    
    // Use this for initialization
    void Start()
    {
        Activate(defaultOldOldTurretShopEntry);
    }

    
}
