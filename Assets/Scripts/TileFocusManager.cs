using PrimitiveFocus;
using UnityEngine;

public class TileFocusManager : ExclusiveSubsectionFocusManager
{
    [SerializeField] private ActiveRegionFocus focusRegion;
    private TileSelectionManager selectionManager;
    
    private void Awake()
    {
        selectionManager = GetComponent<TileSelectionManager>();
    }
    public bool IsActiveFocusRegion()
    {
        return focusRegion.IsActive(this);
    }
    
    public override void Activate(IFocusInteractor item)
    {
        if (!focusRegion.IsActive(this)) return;
        base.Activate(item);
    }

    public override void OnActivate()
    {
        if (selectionManager.GetActive() != null)
        {
            selectionManager.AttemptToFocusSelectedObject();
            Activate(selectionManager.GetActive().GetFocusInteractor());
        }

        base.OnActivate();
    }

    public override void OnInactivate()
    {
        InactivateAll();
        base.OnInactivate();
    }
}