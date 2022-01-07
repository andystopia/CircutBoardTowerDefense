using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class RecursiveRendererBoundsFocusable : RendererBoundsFocusable
{
    private Renderer[] renderers;
    private Bounds bounds;
    private Renderer currentRenderer;

    protected virtual void Start()
    {
        currentRenderer = GetComponent<Renderer>();
        renderers = GetComponentsInChildren<Renderer>();
        MeshFilter filter;
        if (TryGetComponent(out filter))
        {
            filter.mesh.RecalculateBounds();
        }

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
    public override Bounds FocusBounds => bounds;
    

    
    public override void OnActivate()
    {
        // just do nothing by default
    }

    public override void OnInactivate()
    {
        // just do nothing by default.
    }
}