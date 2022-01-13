using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public abstract class EnemyPathBase : ScriptableObject
{
    public abstract IEnemyPathIntermediateValueExtrapolator GetExtrapolator();
}

[CreateAssetMenu(fileName = "Enemy Path", menuName = "Enemy Path/Absolute Path", order = 0)]
public class AbsoluteEnemyPath : ScriptableObject /* EnemyPathBase */
{
    [SerializeField] private List<GridLocation> points;

    public List<GridLocation> Points => points;

    // public override IEnumerator<GridLocation> CreateLocationEnumerator()
    // {
    //     return points.GetEnumerator();
    // }

    public override string ToString()
    {
        return $"{base.ToString()}, Points: {points}";
    }
}