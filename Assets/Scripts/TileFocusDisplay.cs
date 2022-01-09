
using System;
using UnityEngine;

public class TileFocusDisplay : MonoBehaviour, ITileFocusDisplay
{
    private RendererBoundsFocusable focusable;
    private FocusIndicator focus;
    private Color focusColor;

    protected virtual void Awake()
    {
        focusable = GetComponent<RendererBoundsFocusable>();
    }

    public void Init(FocusIndicator indicator)
    {
        focus = indicator;
    }

    public void SetFocusColor(Color focusColor)
    {
        this.focusColor = focusColor;
    }
    

    public void Show()
    {
        focus.FocusOn(focusable, focusColor);
    }

    public void Hide()
    {
        focus.StopFocusOn(focusable);
    }
}