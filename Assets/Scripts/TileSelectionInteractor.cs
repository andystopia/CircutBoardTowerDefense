
using System;
using System.Runtime.CompilerServices;
using ActiveOrInactiveStateManagement;
using ObserverPattern;
using PrimitiveFocus;
using Tile;
using UnityEngine;
using UnityEngine.PlayerLoop;


/// <summary>
/// The interaction between the tile and the 
/// </summary>
public class TileSelectionInteractor : MonoBehaviour, ITileSelectionInteractor
{
    private BasicExclusiveStateManager<ITileSelectionInteractor> tileSelectionManager;
    [SerializeField] private GameObject tileText;
    private BasicExclusiveStateManager<IOldTurretShopBehavior> turretShop;
    private EnergyCounter energyCounter;

    private ITileTurretBehavior turretBehavior;
    private ITileRangeIndicator rangeIndicator;
    private IGridPositionedItem gridPosition;
    private ITileExclusiveFocusInteractor focusInteractor;


    public IGridPositionedItem GetGridPositionedComponent()
    {
        return gridPosition;
    }

    private void Awake()
    {
        turretBehavior = GetComponent<ITileTurretBehavior>();
        rangeIndicator = GetComponent<ITileRangeIndicator>();
        
        // note if you use, `IGridPositionedItem`, you will find
        // that this class will satisfy it, even though it shouldn't
        // and doing that will cause a self-reference, which will
        // lead to a stack overflow on the call to GetLocation.
        gridPosition = GetComponent<IGridPositionedItem>();
        focusInteractor = GetComponent<ITileExclusiveFocusInteractor>();

    }
    
    public void Init(EnergyCounter energyCounter, BasicExclusiveStateManager<IOldTurretShopBehavior> turretShop, BasicExclusiveStateManager<ITileSelectionInteractor> tileSelectionManager, ExclusiveSubsectionFocusManager focusManager)
    {
        this.energyCounter = energyCounter;
        this.turretShop = turretShop;
        this.tileSelectionManager = tileSelectionManager;
    }
    
    private void OnMouseDown()
    {
        AttemptToPlaceTurret();
    }

    public (FilledState, TurretShopSelectionStatus) GetState()
    {
        var filledState = turretBehavior.GetTurret() != null ? FilledState.Filled : FilledState.Empty;
        TurretShopSelectionStatus affordability;

        if (turretShop.GetActive() == null)
        {
            affordability = TurretShopSelectionStatus.NoActiveTurret;
        } 
        else if (turretShop.GetActive().GetEnergyCost() <= energyCounter.energy)
        {
            affordability = TurretShopSelectionStatus.AffordableActiveTurret;
        }
        else
        {
            affordability = TurretShopSelectionStatus.TooExpensiveActiveTurret;
        }
        
        return (filledState, affordability);
    } 

    public void Hovered()
    {
        if (turretBehavior.GetTurret() == null) // if the tile has no turret in it
        {
            if (turretShop.GetActive() != null)
            {
                if (turretShop.GetActive().GetEnergyCost() <= energyCounter.energy)
                {
                    // focusInteractor.SetFocusDisplayColor(Color.green);


                    // show the range
                    rangeIndicator.SetRange(turretShop.GetActive().AssociatedTurretPrefab().range);
                    rangeIndicator.Show();
                }
                else
                {
                    // focusInteractor.SetFocusDisplayColor(Color.red);
                }
            }
            else
            {
                // focusInteractor.SetFocusDisplayColor(Color.white);
            }
        }
        else
        {
            if (turretShop.GetActive() != null)
            {
                // focusInteractor.SetFocusDisplayColor(Color.red);
            }
            else
            {
                // for future possible tile menu.
                // focusInteractor.SetFocusDisplayColor(Color.white);
            }
        }
    }
    
    public void UnHovered()
    {
        rangeIndicator.Hide();
    }

    public void AttemptToPlaceTurret()
    {
        if (turretBehavior.GetTurret() == null)
        {
            if (turretShop.GetActive() != null)
            {
                if (turretShop.GetActive().GetEnergyCost() <= energyCounter.energy)
                {
                    var turret = turretShop.GetActive().AssociatedTurretPrefab();

                    energyCounter.energy -= turretShop.GetActive().GetEnergyCost();
                    Vector3 spawnPos = new Vector3(transform.position.x, -0.5f, transform.position.z);
                    turretBehavior.SetTurret(Instantiate(turret, spawnPos, transform.rotation));
                }
                else
                {
                    DisplayWarningText("You Can't Afford That.");
                }

            }
        }
        else
        {
            if (turretShop.GetActive() != null)
            {
                DisplayWarningText("You Can't Place That Here.");
            }
            else
            {
                // we'll get here eventually.
                // openTileMenu();
            }
        }
    }
    
    

    /// <summary>
    /// Displays warning text on screen.
    ///
    /// This should almost certainly
    /// be another component.
    /// </summary>
    /// <param name="text"> the text to display</param>
    private void DisplayWarningText(string text)
    {
        Vector3 spawnPos = new Vector3(0, 8, 0);
        var gO = Instantiate(tileText, spawnPos, Quaternion.identity, transform);
        gO.GetComponent<TextMesh>().text = text;
        gO.GetComponent<Transform>().rotation = new Quaternion(90, 0, 0, 90);
    }


        
    /// <summary>
    /// In this case, the active state is represents
    /// the state of the square being "selected".
    ///
    /// "selected" is a vague term in this cause,
    /// but basically, all it's going to do is be able
    /// to draw a focus element over this element.
    ///
    /// This method cannot be called to set it's own active
    /// state. This is an event function.
    /// </summary>
    public void OnActivate()
    {
        // focusInteractor.GetManager().Activate(focusInteractor);
        Hovered();
    }
    
    public void OnInactivate()
    {
        UnHovered();
    }

    public IFocusInteractor GetFocusInteractor()
    {
        return focusInteractor;
    }

    protected void OnMouseEnter()
    {
        tileSelectionManager.Activate(this);
    }

    protected void OnMouseExit()
    {
        tileSelectionManager.InactivateIfActive(this);
    }
}