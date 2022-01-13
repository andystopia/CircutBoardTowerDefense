using ActiveOrInactiveStateManagement;
using TurretBehaviour;
using UnityEngine;


public class OldTurretShopEntry : MonoBehaviour, ITurretShopEntryBehavior
{
    [SerializeField] private BasicTogglableExclusiveStateManager<ITurretShopEntryBehavior> shop;
    
    [SerializeField] private Turret shopTurret;
    public GameObject litDisplay;
    public GameObject deleteDisplay;
    public GameObject turretMouseDrag;

    [SerializeField] private float energyCost;
    
    private GameManager gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private bool IsSelected()
    {
        return ReferenceEquals(shop.GetActive(), this);
    }

    private void OnMouseDown()
    {
        // if (!gameManagerScript.inTileMenu)
        // {
            shop.ToggleActive(this);
        // }
    }


    public void OnActivate()
    {
        litDisplay.SetActive(true);
    }

    public void OnInactivate()
    {
        litDisplay.SetActive(false);
    }

    public Turret AssociatedTurretPrefab()
    {
        return shopTurret;
    }

    public float GetEnergyCost()
    {
        return energyCost;
    }
}