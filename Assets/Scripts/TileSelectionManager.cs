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

    public override void Activate(ITileSelectionInteractor item)
    {
        if (focusManager.IsActiveFocusRegion())
        {
            base.Activate(item);
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
