
using System;
using ActiveOrInactiveStateManagement;
using UnityEngine;

public class ActiveRegionFocus : BasicTogglableExclusiveStateManager<IFocusableRegion>
{
    [SerializeField] private MonoBehaviour defaultRegion;

    private void Start()
    {
        if (!defaultRegion.TryGetComponent(out IFocusableRegion focusableRegion)) {
            Debug.LogWarning("Default focused object cannot be focused. This is unrecommended.");
        }
        Activate(focusableRegion);
    }
}