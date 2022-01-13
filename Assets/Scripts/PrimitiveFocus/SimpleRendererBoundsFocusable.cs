using UnityEngine;

public abstract class SimpleRendererBoundsFocusable : RendererBoundsFocusable
{
    protected Bounds bounds;
    protected Renderer currentRenderer;

    public override Bounds FocusBounds => bounds;

    private void Start()
    {
        currentRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        bounds = currentRenderer.bounds;
    }
}