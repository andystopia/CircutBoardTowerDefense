
using System;
using System.Collections.Generic;
using ActiveOrInactiveStateManagement;
using UnityEngine;
using UnityEngine.PlayerLoop;

public abstract class RendererBoundsFocusable : MonoBehaviour, IFocusable
{
    public abstract void OnActivate();
    public abstract void OnInactivate();

    public abstract Bounds FocusBounds { get; }
}