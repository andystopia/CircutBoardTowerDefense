
using System;
using System.Collections;
using UnityEngine;

public class TileRangeIndicatorUsingGameObject : MonoBehaviour, ITileRangeIndicator
{
    [SerializeField] private GameObject rangeObject;


    public GameObject RangeObject => rangeObject;
    
    public virtual void Show()
    {
        rangeObject.SetActive(true);
    }

    public virtual void Hide()
    {
        rangeObject.SetActive(false);
    }

    public virtual void SetRange(float range)
    {
        rangeObject.transform.localScale = new Vector3(range / 2, range / 2, 1);
    }
}