using UnityEngine;

public class RecursiveRendererBoundsFocusable : RendererBoundsFocusable
{
    private Bounds bounds;
    private Renderer currentRenderer;
    private Renderer[] renderers;
    public override Bounds FocusBounds => bounds;

    protected virtual void Start()
    {
        currentRenderer = GetComponent<Renderer>();
        renderers = GetComponentsInChildren<Renderer>();
        MeshFilter filter;
        if (TryGetComponent(out filter)) filter.mesh.RecalculateBounds();

        CalculateBounds();
    }

    protected virtual void Update()
    {
        CalculateBounds();
    }

    protected void CalculateBounds()
    {
        bounds = GameObjectHelper.GetBounds(currentRenderer, renderers, transform.position);
    }


    public override void OnActivate()
    {
        // just do nothing by default
    }

    public override void OnInactivate()
    {
        // just do nothing by default.
    }
}