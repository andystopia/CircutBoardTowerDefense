using UnityEngine;

namespace PathGrid
{
    public class PathDisplayManager : MonoBehaviour
    {
        [SerializeField] private EnemyPathManager enemyPathManager;
        [SerializeField] private PathGridItem pathGridPrefab;

        private PathGrid grid;

        private void Awake()
        {
            grid = new PathGrid(new Dimensions<int>(21, 13), enemyPathManager.GetActivePath(), pathGridPrefab);
        }
    }
}