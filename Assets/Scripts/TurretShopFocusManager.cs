using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ActiveOrInactiveStateManagement;
using PrimitiveFocus;
using UnityEngine;
using UnityEngine.UIElements;


public class TurretShopFocusManager : ExclusiveSubsectionFocusManager
{
    [SerializeField] private ActiveRegionFocus activeRegionFocus;
    private IActiveStateManager<IOldTurretShopBehavior> selectedManager;
    private CircularCollection<TurretShopEntry> entries;
    private IFloatingUIComponent uiDisplayer;
    private TurretShopDisplay display;

    private IList<TurretShopEntry> GetChildrenTurretShopEntries()
    {
        return GetComponentsInChildren<TurretShopEntry>();
    }
    private void Awake()
    {
        display = GetComponent<TurretShopDisplay>();
    }
     private void Start()
    {
        selectedManager = GetComponent<IActiveStateManager<IOldTurretShopBehavior>>();
        uiDisplayer = GetComponent<IFloatingUIComponent>();

        entries = new CircularCollection<TurretShopEntry>(GetChildrenTurretShopEntries());
    }
    

    private void HandleKeyboardInput()
    {
        if (!activeRegionFocus.IsActive(this))
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                uiDisplayer.Show();
                activeRegionFocus.Activate(this);
                var newEntry = entries.GetList()[0];

                var entryDisplay = newEntry.GetFocusDisplay();
                entryDisplay.SetFocusCenter(entryDisplay.GetOriginalFocusCenter() + (uiDisplayer.GetDestinationPosition() - uiDisplayer.GetStartingPosition()));
                Activate(newEntry.GetFocusInteractor());
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
                uiDisplayer.Hide();
                // make sure none of our children are focused
                InactivateAll();
                // hand over control to the main manager:
                activeRegionFocus.InactivateIfActive(this);
            }
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Tab) && !Input.GetKey(KeyCode.LeftShift))
        {
            var newEntry = entries.MoveToNext();
            Activate(newEntry.GetFocusInteractor());
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Tab) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            var newEntry = entries.MoveToPrevious();
            Activate(newEntry.GetFocusInteractor());
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.X))
        {
            selectedManager.Activate(entries.GetActive());
        }
    }

    private void FixFocusCenter(ITurretShopEntryFocusDisplay focusDisplay)
    {
        if (focusDisplay == null) return;
        focusDisplay.SetFocusCenter(focusDisplay.GetOriginalFocusCenter() + (uiDisplayer.GetDestinationPosition() - uiDisplayer.GetCurrentPosition()));
    }
    private void Update()
    {
        HandleKeyboardInput();
        if (GetActive() != null)
        {
            FixFocusCenter(((ITurretShopEntryFocusInteractor) GetActive()).GetFocusDisplay());
        }
    }

    public override void OnInactivate()
    {
        display.Hide();
        base.OnInactivate();
    }
}