using ActiveOrInactiveStateManagement;
using UnityEngine;

public class FullTurretShop : BasicTogglableExclusiveStateManager<ITurretShopEntryBehavior>
{
    /// <summary>
    ///     The default turret in the shop
    ///     that should be selected, should
    ///     probably be null/None.
    /// </summary>
    [SerializeField] private OldTurretShopEntry defaultTurretShopEntry;

    // Use this for initialization
    private void Start()
    {
        Activate(defaultTurretShopEntry);
    }
}