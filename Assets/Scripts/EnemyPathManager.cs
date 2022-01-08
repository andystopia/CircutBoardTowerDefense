using UnityEngine;

public class EnemyPathManager : MonoBehaviour
{
    [SerializeField] private EnemyPath path;

    public virtual EnemyPath GetActivePath()
    {
        return path;
    }
}