using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "Enemy Path", menuName = "Enemy Path", order = 0)]
public class EnemyPath : ScriptableObject
{
    [SerializeField]
    private List<GridLocation> values;
}