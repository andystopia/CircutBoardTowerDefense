
using ActiveOrInactiveStateManagement;
using UnityEngine;

public class TranslatedFocusable : IFocusable
{
    private readonly IFocusable underlying;
    private readonly Vector3 translation;

    public TranslatedFocusable(IFocusable underlying, Vector3 translation)
    {
        this.underlying = underlying;
        this.translation = translation;
    }

    public void OnActivate()
    {
        underlying.OnActivate();
    }

    public void OnInactivate()
    {
        underlying.OnInactivate();
    }
    

    public Bounds FocusBounds
    {
        get
        {
            // apply translation.
            var bounds = underlying.FocusBounds;
            bounds.center = translation;
            return bounds;
        }
    }
}


public class TurretShopEntryFocusDisplay : MonoBehaviour, ITurretShopEntryFocusDisplay
{
    [SerializeField] private FocusIndicator focus;
    private TurretShopEntry entry;
    private RecursiveRendererBoundsFocusable focusBounds;

    private IFocusable shifted;
    protected virtual void Start()
    {
        entry = GetComponent<TurretShopEntry>();
        focusBounds = GetComponent<RecursiveRendererBoundsFocusable>();
        shifted = focusBounds;
    }
    
    public TurretShopEntry GetEntry()
    {
        return entry;
    }

    public Vector3 GetOriginalFocusCenter()
    {
        return focusBounds.FocusBounds.center;
    }
    
    public void SetFocusCenter(Vector3 location)
    {
        shifted = new TranslatedFocusable(focusBounds, location);
    }

    public void Show()
    {
        focus.FocusOn(shifted);
    }
    

    public void Hide()
    {
        focus.StopFocusOn(shifted);
    }
}