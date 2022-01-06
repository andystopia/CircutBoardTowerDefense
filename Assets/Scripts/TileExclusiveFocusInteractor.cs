
using System;
using ActiveOrInactiveStateManagement;
using ObserverPattern;
using PrimitiveFocus;
using UnityEngine;
using UnityEngine.Assertions;

public class TileExclusiveFocusInteractor : ExclusiveFocusInteractor, ITileExclusiveFocusInteractor
{
    private ITileFocusDisplay display;
    private void Awake()
    {
        display = GetComponent<ITileFocusDisplay>();
        
        // make sure we're the only one who is using this interface on this object.
        GameObjectHelper.AssertOnlyComponentOfType<IExclusiveFocusInteractor>(this);
    }

    private void Start()
    {
        Assert.IsNotNull(GetFocusManager(), $"{GetType().Name} didn't get a manager");
    }


    public void SetFocusDisplayColor(Color focusColor)
    {
        display.SetFocusColor(focusColor);
    }
    
    
    public override void OnActivate()
    {
        display.Show();
    }

    public override void OnInactivate()
    {
        display.Hide();
    }


    protected void OnMouseEnter()
    {
        GetManager().Activate(this);
    }

    protected void OnMouseExit()
    {
        GetManager().InactivateIfActive(this);
    }

}