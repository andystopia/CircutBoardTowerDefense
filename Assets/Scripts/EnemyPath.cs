using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "Enemy Path", menuName = "Enemy Path", order = 0)]
public class EnemyPath : ScriptableObject
{
    [SerializeField] private List<GridLocation> points;

    public List<GridLocation> Points => points;


    public IEnumerator<GridLocation> CreateLocationEnumerator()
    {
        return points.GetEnumerator();
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Points: {points}";
    }
}
