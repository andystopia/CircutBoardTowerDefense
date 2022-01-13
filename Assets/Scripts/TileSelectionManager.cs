using System;
using ActiveOrInactiveStateManagement;
using UnityEngine;

public class TileSelectionManager : BasicTogglableExclusiveStateManager<ITileSelectionInteractor>
{
    private TileCreationManager creationManager;
    private TileFocusManager focusManager;

    public void Awake()
    {
        creationManager = GetComponent<TileCreationManager>();
        focusManager = GetComponent<TileFocusManager>();
    }
    
    
    protected virtual void Update()
    {
        if (GetActive() == null) return;
        if (focusManager.GetActive() != GetActive().Root.GetFocusInteractor())
        {
            focusManager.Activate(GetActive().Root.GetFocusInteractor());
        }
    }



    public void AttemptToFocusSelectedObject()
    {
        if (GetActive() != null)
        {
            GetActive().Hovered();
        }
    }
    #region FocusRegionBehavior
    public void OnActivate()
    {
        AttemptToFocusSelectedObject();
    }

    public void OnInactivate()
    {
        if (GetActive() != null)
        {
            GetActive().UnHovered();
        }
    }
    #endregion
}
