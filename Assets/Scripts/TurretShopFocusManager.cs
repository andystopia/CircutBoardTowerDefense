using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ActiveOrInactiveStateManagement;
using PrimitiveFocus;
using TurretShopEntry;
using UnityEngine;
using UnityEngine.UIElements;
using IFocusDisplay = TurretShopEntry.IFocusDisplay;
using IFocusInteractor = TurretShopEntry.IFocusInteractor;


public class TurretShopFocusManager : ExclusiveSubsectionFocusManager
{
    [SerializeField] private ActiveRegionFocus activeRegionFocus;
    private IExclusiveStateManager<ISelectionInteractor> selectedManager;
    private CircularCollection<TurretShopEntry.FocusInteractor> entries;
    private IFloatingUIComponent uiDisplayer;
    private TurretShopDisplay display;

    private IList<TurretShopEntry.FocusInteractor> GetChildrenTurretShopEntries()
    {
        return GetComponentsInChildren<TurretShopEntry.FocusInteractor>();
    }
    private void Awake()
    {        
        selectedManager = GetComponent<IExclusiveStateManager<ISelectionInteractor>>();
        display = GetComponent<TurretShopDisplay>();
    }
     private void Start()
    {
        uiDisplayer = GetComponent<IFloatingUIComponent>();

        var childrenTurretShopEntries = GetChildrenTurretShopEntries();
        
        foreach (var childrenTurretShopEntry in childrenTurretShopEntries)
        {
            childrenTurretShopEntry.SetManager(this);
        }
        entries = new CircularCollection<TurretShopEntry.FocusInteractor>(childrenTurretShopEntries);
    }
    

    private void HandleKeyboardInput()
    {
        if (!activeRegionFocus.IsActive(this))
        {
            
            if (Input.GetKeyDown(KeyCode.Z))
            {
                // uiDisplayer.Show();
                activeRegionFocus.Activate(this);

                var active = GetActive();
                var toSelect = selectedManager.GetActive().Root.FocusInteractor ?? entries.GetList()[0];

                // var entryDisplay = newEntry.GetFocusDisplay();
                // entryDisplay.SetFocusCenter(entryDisplay.GetOriginalFocusCenter() + (uiDisplayer.GetDestinationPosition() - uiDisplayer.GetStartingPosition()));
                Activate(toSelect);
            }
            else
            {
                return;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                // uiDisplayer.Hide();
                // make sure none of our children are focused
                InactivateAll();
                // hand over control to the main manager:
                activeRegionFocus.InactivateIfActive(this);
            }
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Tab) && !Input.GetKey(KeyCode.LeftShift))
        {
            var newEntry = entries.MoveToNext();
            Activate(newEntry);
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Tab) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            var newEntry = entries.MoveToPrevious();
            Activate(newEntry);
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.X) && entries.GetActive() != null)
        {
            selectedManager.Activate(entries.GetActive().Root.SelectionInteractor);
        }
    }

    private void FixFocusCenter(IFocusDisplay focusDisplay)
    {
        if (focusDisplay == null) return;
        // focusDisplay.SetFocusCenter(focusDisplay.GetOriginalFocusCenter() + (uiDisplayer.GetDestinationPosition() - uiDisplayer.GetCurrentPosition()));
    }
    private void Update()
    {
        HandleKeyboardInput();
        if (GetActive() != null)
        {
            FixFocusCenter(((IFocusInteractor) GetActive()).GetFocusDisplay());
        }
    }

    public override void OnInactivate()
    {
        // display.Hide();
        base.OnInactivate();
    }
}