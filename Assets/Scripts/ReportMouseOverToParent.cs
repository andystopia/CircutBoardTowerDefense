using System;
using System.Collections;
using System.Collections.Generic;
using TurretShopEntry;
using UnityEngine;

public class ReportMouseOverToParent : MonoBehaviour
{

    private FocusInteractor parent;

    public void Start()
    {
        parent = transform.parent.gameObject.GetComponent<FocusInteractor>();
    }

    // private void OnMouseDown()
    // {
    //     parent.OnMouseDown();
    // }
    //
    // private void OnMouseEnter()
    // {
    //     parent.OnMouseEnter();
    // }
    //
    // private void OnMouseExit()
    // {
    //     parent.OnMouseExit();
    // }
    //
    // private void OnMouseOver()
    // {
    //     parent.OnMouseOver();
    // }
    //
    // private void OnMouseUp()
    // {
    //     parent.OnMouseUp();
    // }
}
