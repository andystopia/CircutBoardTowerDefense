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
        Debug.Log("TileFocusManager::Activate called", this);
        if (!focusRegion.IsActive(this)) return;
        Debug.Log("TileFocusManager::Activate passed it's guard.", this);
        base.Activate(item);
    }

    public override void OnActivate()
    {
        Debug.Log("TileFocusManager::OnActivate called",this);
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