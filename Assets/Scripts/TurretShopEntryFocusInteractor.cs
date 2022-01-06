using System;
using System.Collections;
using System.Collections.Generic;
using ActiveOrInactiveStateManagement;
using ObserverPattern;
using PrimitiveFocus;
using UnityEngine;

public class TurretShopEntryFocusInteractor : ExclusiveFocusInteractor, ITurretShopEntryFocusInteractor
{
    private ITurretShopEntryFocusDisplay display;
    private void Awake()
    {
        display = GetComponent<ITurretShopEntryFocusDisplay>();
    }

    public ITurretShopEntryFocusDisplay GetFocusDisplay()
    {
        return display;
    }

    public override void OnActivate()
    {
        display.Show();
        base.OnActivate();
    }

    public override void OnInactivate()
    {
        display.Hide();
        base.OnInactivate();
    }

    protected virtual void OnMouseEnter()
    {
        GetManager().Activate(this);
    }

    protected virtual void OnMouseExit()
    {
        GetManager().InactivateIfActive(this);
    }
}
