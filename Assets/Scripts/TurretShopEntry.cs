using System;
using ActiveOrInactiveStateManagement;
using TMPro;
using TurretBehaviour;
using UnityEngine;

public class TurretShopEntry : MonoBehaviour, IOldTurretShopBehavior
{
    private ITurretShopEntryFocusInteractor focusInteractor;
    public Sprite sprite;
    public string turretName;
    public int cost;
    public TurretPlayState turret;

    public GameManager manager;
    // private GameObject background;

    // private SpriteRenderer backgroundRenderer;

    [SerializeField] private BasicExclusiveStateManager<IOldTurretShopBehavior> man;
    [SerializeField] private OldTurretShopEntry associated;
    [SerializeField] private TurretShopFocusManager focusManager;
    [SerializeField] private TextMeshPro label;

    private ITurretShopEntryFocusDisplay focusDisplay;

    public void OnActivate()
    {
        man.Activate(associated);
    }

    public void OnInactivate()
    {
        man.InactivateIfActive(associated);
    }

    public ITurretShopEntryFocusInteractor GetFocusInteractor()
    {
        return focusInteractor;
    }
    
    
    // Start is called before the first frame update

    private void Awake()
    {
        focusInteractor = GetComponent<ITurretShopEntryFocusInteractor>();
        focusDisplay = GetComponent<ITurretShopEntryFocusDisplay>();
    }

    void Start()
    {
        transform.Find("Icon").GetComponent<SpriteRenderer>().sprite = sprite;
        // background = transform.Find("Background").gameObject;
        transform.Find("EnergyCost").GetComponent<TextMeshPro>().text = $"Cost: {cost}";
        GetComponent<ITurretShopEntryFocusInteractor>().SetManager(focusManager);
        // backgroundRenderer = background.GetComponent<SpriteRenderer>();
        label.text = turretName;
    }

    public TurretPlayState AssociatedTurretPrefab()
    {
        return turret;
    }

    public float GetEnergyCost()
    {
        return turret.EnergyCost;
    }

    private void OnMouseDown()
    {
        man.Activate(associated);
    }

    public ITurretShopEntryFocusDisplay GetFocusDisplay()
    {
        return focusDisplay;
    }
}
