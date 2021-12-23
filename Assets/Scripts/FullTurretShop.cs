using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class FullTurretShop : MonoBehaviour
{
    /// <summary>
    /// Maintain a list of all
    /// possible <c>TurretShop</c>'s
    /// that can be purchasable.
    /// </summary>
    public List<TurretShop> purchasableTurrets;
    /// <summary>
    /// The currently selected turret shop.
    /// This variable should probably only
    /// be accessed by it's nonCamelCase
    /// variant.
    /// </summary>
    private TurretShop selectedShop;
    /// <summary>
    /// The default turret in the shop
    /// that should be selected, should
    /// probably be null/None.
    /// </summary>
    public TurretShop defaultTurretShop;


    /// <summary>
    /// Accesses and Mutates the
    /// selected turret in the shop
    /// in an encapsulated manner.
    /// </summary>
    public TurretShop SelectedShop
    {
        get
        {
            return selectedShop;
        }
        set
        {
            // note: available for future optimization

            // disable all the turrets.
            foreach (TurretShop ts in purchasableTurrets)
            {
                ts.litDisplay.SetActive(false);
            }
            // don't deref a null pointer.
            if (value != null)
            {
                value.litDisplay.SetActive(true);
            }
            selectedShop = value;
        }
    }


    /// <summary>
    /// Toggles the active shop.
    ///
    /// That is, if the current shop is the
    /// passed parameter, then disable all
    /// the shops.
    ///
    /// If the current shop is not the
    /// passed parameter, then disable all
    /// other shops, and set the current shop
    /// to be the passed <c>shop</c>.
    /// </summary>
    /// <param name="shop"></param>
    public void ToggleActiveShop(TurretShop shop)
    {
        if (ReferenceEquals(SelectedShop, shop))
        {
            SelectedShop = null;
        }
        else
        {
            SelectedShop = shop;
        }
    }
    
    // Use this for initialization
    void Start()
    {
        // set the selected shop to the default
        // turret shop.
        SelectedShop = defaultTurretShop;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
