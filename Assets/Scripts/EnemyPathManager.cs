using System.Linq;
using UnityEngine;

public class EnemyPathManager : MonoBehaviour
{
    [SerializeField] private EnemyPathBase path;

    /// <summary>
    /// A cache of the start node of the active
    /// path so that way users of this class
    /// can access the start node in a similar
    /// way to the end node.
    /// </summary>
    public IEnemyPathNode ActiveStartNode { get; protected set; }

    /// <summary>
    /// A cache of the end node of the active path
    /// so that way users of this class don't
    /// need to generate the entire path just
    /// for the last node.
    /// </summary>
    public IEnemyPathNode ActiveEndNode { get; protected set; }

    protected virtual void Awake()
    {
        RecalculateStartAndEndNodes();
    }

    protected virtual void RecalculateStartAndEndNodes()
    {
        ActiveStartNode = path.GetExtrapolator().GetMinimalRepresentation().First();
        ActiveEndNode = path.GetExtrapolator().GetMinimalRepresentation().Last();
    }

    public virtual EnemyPathBase GetActivePath()
    {
        return path;
    }
}