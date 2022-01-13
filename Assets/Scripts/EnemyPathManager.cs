using UnityEngine;

public class EnemyPathManager : MonoBehaviour
{
    [SerializeField] private EnemyPathBase path;

    public virtual EnemyPathBase GetActivePath()
    {
        return path;
    }
}