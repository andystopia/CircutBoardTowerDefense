
using System;
using System.Collections;
using UnityEngine;

class TileRangeIndicatorUsingGameObject : MonoBehaviour, ITileRangeIndicator
{
    [SerializeField] private GameObject rangeObject;

    public void Show()
    {
        rangeObject.SetActive(true);
    }

    public void Hide()
    {
        rangeObject.SetActive(false);
    }

    public void SetRange(float range)
    {
        rangeObject.transform.localScale = new Vector3(range - 1, range - 1, 1);
    }
}