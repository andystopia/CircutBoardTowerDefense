using System.Collections;
using System.Collections.Generic;
using ActiveOrInactiveStateManagement;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// A class that represents the entire turret shop collection.
///
/// A turret must be registered with this class in unity
/// before it can be used as the active turret.
/// </summary>
public class TurretShop : BasicExclusiveStateManager<IOldTurretShopBehavior>
{
    private List<TurretShopEntry> childEntries;
    private CircularCollection<TurretShopEntry> entries;



    private void Start()
    {
        entries = new CircularCollection<TurretShopEntry>(childEntries);
        // focusManager = GetComponent<TurretShopFocusManager>();
    }
}
