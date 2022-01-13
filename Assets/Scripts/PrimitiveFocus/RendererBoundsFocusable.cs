using UnityEngine;

public abstract class RendererBoundsFocusable : MonoBehaviour, IFocusable
{
    public abstract void OnActivate();
    public abstract void OnInactivate();

    public abstract Bounds FocusBounds { get; }
}