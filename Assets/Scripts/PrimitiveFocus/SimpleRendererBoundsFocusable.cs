using UnityEngine;

public abstract class SimpleRendererBoundsFocusable : RendererBoundsFocusable
{
    protected Renderer currentRenderer;
    protected Bounds bounds;
    
    private void Start()
    {
        currentRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        bounds = currentRenderer.bounds;
    }

    public override Bounds FocusBounds => bounds;
}